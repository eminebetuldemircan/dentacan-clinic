using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos.AppointmentDtos;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Business.Concrete
{
    public class AppointmentService : IAppointmentService
    {
        IAppointmentChangeTokenRepository _AppointmentChangeTokenRepository;
        IAppointmentRepository _AppointmentRepository;
        IDoctorRepository _DoctorRepository;
        IMapper _mapper;

       

        public AppointmentService(IAppointmentRepository AppointmentRepository, IDoctorRepository DoctorRepository, IAppointmentChangeTokenRepository AppointmentChangeTokenRepository, IMapper mapper)
        {
            _AppointmentChangeTokenRepository = AppointmentChangeTokenRepository;
            _AppointmentRepository = AppointmentRepository;
            _DoctorRepository = DoctorRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(AppointmentCreateDto entity)
        {

            var existingAppointmentSameDoctorIdDateTime = await _AppointmentRepository.GetListAsync(a => a.Date == entity.Date && a.Time == entity.Time && a.DoctorId == entity.DoctorId);

            if (existingAppointmentSameDoctorIdDateTime.Any())
            {
                return new ErrorResult(Messages.SameDateTimeDoctorAlreadyExists);
            }

            var newAppointment = _mapper.Map<Appointment>(entity);
            var VerificationCode = GenerateVerificationCode();
            newAppointment.VerificationCode = VerificationCode;


            await _AppointmentRepository.AddAsync(newAppointment);
            string description = $"Randevu oluşturulmuştur. Randevu tarihi: {newAppointment.Date} saat: {newAppointment.Time}";
            EmailHelper.SendVerificationCode(newAppointment.Email, VerificationCode, newAppointment.Id,description);

            return new SuccessResult(Messages.Added);
        }


        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // 6 haneli sayı
        }
        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var getAppointment = await _AppointmentRepository.GetAsync(x => x.Id == id);
            if (getAppointment == null)
            {
                return new ErrorDataResult<bool>(false, Messages.Deleted);
            }
            var isDelete = await _AppointmentRepository.DeleteAsync(id);
            var deleteNextDate = DateTime.Parse(getAppointment.Date).AddDays(1).Date.ToString("yyyy-MM-dd");
         
            var getNextAppointment = await _AppointmentRepository.GetAsync(x => x.Date == deleteNextDate && x.IsVerification==true && x.DoctorId== getAppointment.DoctorId);

            if (getNextAppointment != null)
            {
                string token = GenerateSecureToken();

                await _AppointmentChangeTokenRepository.AddAsync(new Entities.Concrete.AppointmentChangeToken
                {
                    Token = token,
                    EmptyAppointmentDate = getAppointment.Date,
                    EmptyAppointmentTime = getAppointment.Time,
                    OldAppointmentId = getNextAppointment.Id,
                    ExpirationDate = DateTime.Now.AddMinutes(300),
                    IsUsed = false

                });
                string description = $"Yeni Randevu açılmıştır. Yeni randevu tarihi: {getNextAppointment.Date} saat: {getNextAppointment.Time}";
                EmailHelper.SendChangeToken(getNextAppointment.Email, token,description);
            }
                return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
         
        }
        public async Task<IDataResult<AppointmentDetailDto>> GetAsync(Expression<Func<Appointment, bool>> filter)
        {
            var Appointment = await _AppointmentRepository.GetAsync(filter);
            if (Appointment != null)
            {
                var AppointmentDetailDto = _mapper.Map<AppointmentDetailDto>(Appointment);
                return new SuccessDataResult<AppointmentDetailDto>(AppointmentDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<AppointmentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<AppointmentDetailDto>> GetByIdAsync(int id)
        {
            var Appointment = await _AppointmentRepository.GetAsync(x => x.Id == id);
            if (Appointment != null)
            {
                var AppointmentDetailDto = _mapper.Map<AppointmentDetailDto>(Appointment);
                return new SuccessDataResult<AppointmentDetailDto>(AppointmentDetailDto, Messages.Listed);
            }
            return new ErrorDataResult<AppointmentDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<AppointmentListDto>>> GetListAsync(Expression<Func<Appointment, bool>> filter = null)
        {
            List<AppointmentListDto> appointments = new List<AppointmentListDto>();
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _AppointmentRepository.GetListAsync();

                foreach (var appointment in response)
                {
                    var appointmentDto = await AssignAppointmentDetails(appointment, appointment.DoctorId);
                    appointmentDto.IsVerificationName = appointment.IsVerification ? "Doğrulandı" : "Doğrulanmadı";

                    appointments.Add(appointmentDto);
                }
                return new SuccessDataResult<IEnumerable<AppointmentListDto>>(appointments, Messages.Listed);
            }
            else
            {
                var response = await _AppointmentRepository.GetListAsync(filter);

                foreach (var appointment in response)
                {
                    var appointmentDto = await AssignAppointmentDetails(appointment, appointment.DoctorId);
                    appointmentDto.IsVerificationName = appointment.IsVerification ? "Doğrulandı" : "Doğrulanmadı";
                    appointments.Add(appointmentDto);
                }
                return new SuccessDataResult<IEnumerable<AppointmentListDto>>(appointments, Messages.Listed);
            }
        }

        public async Task<IDataResult<AppointmentUpdateDto>> UpdateAsync(AppointmentUpdateDto AppointmentUpdateDto)
        {
            var getAppointment = await _AppointmentRepository.GetAsync(x => x.Id == AppointmentUpdateDto.Id);

            var Appointment = _mapper.Map<Appointment>(AppointmentUpdateDto);


            Appointment.UpdatedTime = DateTime.Now;



            var AppointmentUpdate = await _AppointmentRepository.UpdateAsync(Appointment);
            var resultUpdateDto = _mapper.Map<AppointmentUpdateDto>(AppointmentUpdate);

            return new SuccessDataResult<AppointmentUpdateDto>(resultUpdateDto, Messages.Updated);
        }
        public async Task<IDataResult<bool>> VerificationByIdAsync(int AppointmentId, string verificationCode)
        {
            var getAppointment = await _AppointmentRepository.GetAsync(x => x.Id == AppointmentId);


            if (getAppointment == null)
            {
                return new ErrorDataResult<bool>(false, Messages.IsNotVerification);
            }
            if (getAppointment.VerificationCode != verificationCode)
            {
                return new ErrorDataResult<bool>(false, Messages.IsNotVerification);
            }

            await _AppointmentRepository.VerificationByIdAsync(AppointmentId);


            return new SuccessDataResult<bool>(true, Messages.SuccessVerification);
        }

        public async Task<IDataResult<bool>> ChangeAppointmentAsync(string token)
        {

            var tokenEntry = await _AppointmentChangeTokenRepository.GetAsync(t => t.Token == token && !t.IsUsed && t.ExpirationDate > DateTime.Now);


            if (tokenEntry != null)
            {
                var appointment = await _AppointmentRepository.GetAsync(a => a.Id == tokenEntry.OldAppointmentId);

                if (appointment != null)
                {

                    appointment.Date = tokenEntry.EmptyAppointmentDate;
                    appointment.Time = tokenEntry.EmptyAppointmentTime;

                    await _AppointmentRepository.UpdateAsync(appointment);

                    tokenEntry.IsUsed = true;
                    await _AppointmentChangeTokenRepository.UpdateAsync(tokenEntry);

                    return new SuccessDataResult<bool>(true, Messages.SuccessVerification);
                }
                else
                {
                    return new ErrorDataResult<bool>(false, Messages.InvalidToken);
                }
            }

            return new ErrorDataResult<bool>(false, Messages.InvalidToken);

        }
        private async Task<AppointmentListDto> AssignAppointmentDetails(Appointment appointment, int doctorId)
        {
            var doctor = await _DoctorRepository.GetAsync(x => x.Id == doctorId);
            if (doctor == null)
            {
                return null;
            }



            var appointmentDto = _mapper.Map<AppointmentListDto>(appointment);
            appointmentDto.DoctorName = $"{doctor.Firstname} {doctor.Lastname}";

            return appointmentDto;
        }
        private string GenerateSecureToken(int length = 32)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes)
                             .Replace("+", "")
                             .Replace("/", "")
                             .Replace("=", "")
                             .Substring(0, length);
            }
        }

    }

}
