using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dtos.DoctorDtos;
using Entities.Dtos.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class DoctorService : IDoctorService
    {
        IDoctorRepository _DoctorRepository;
        IMapper _mapper;
        public DoctorService(IDoctorRepository DoctorRepository, IMapper mapper)
        {
            _DoctorRepository = DoctorRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(DoctorCreateDto entity)
        {
            var newDoctor = _mapper.Map<Doctor>(entity);

            await _DoctorRepository.AddAsync(newDoctor);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _DoctorRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<DoctorDetailDto>> GetAsync(Expression<Func<Doctor, bool>> filter)
        {
            var Doctor = await _DoctorRepository.GetAsync(filter);
            if (Doctor != null)
            {
                var DoctorDetailDto = _mapper.Map<DoctorDetailDto>(Doctor);
                return new SuccessDataResult<DoctorDetailDto>(DoctorDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<DoctorDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<DoctorDetailDto>> GetByIdAsync(int id)
        {
            var Doctor = await _DoctorRepository.GetAsync(x => x.Id == id);
            if (Doctor != null)
            {
                var DoctorDetailDto = _mapper.Map<DoctorDetailDto>(Doctor);
                return new SuccessDataResult<DoctorDetailDto>(DoctorDetailDto, Messages.Listed);
            }
            return new ErrorDataResult<DoctorDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<DoctorListDto>>> GetListAsync(Expression<Func<Doctor, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _DoctorRepository.GetListAsync();
                var responseDetailDto = _mapper.Map<IEnumerable<DoctorListDto>>(response);
                return new SuccessDataResult<IEnumerable<DoctorListDto>>(responseDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _DoctorRepository.GetListAsync(filter);
                var responseDetailDto = _mapper.Map<IEnumerable<DoctorListDto>>(response);
                return new SuccessDataResult<IEnumerable<DoctorListDto>>(responseDetailDto, Messages.Listed);
            }
        }

        public async Task<IDataResult<DoctorUpdateDto>> UpdateAsync(DoctorUpdateDto DoctorUpdateDto)
        {
            var getDoctor = await _DoctorRepository.GetAsync(x => x.Id == DoctorUpdateDto.Id);

            var Doctor = _mapper.Map<Doctor>(DoctorUpdateDto);
            Doctor.UpdatedTime = DateTime.Now;



            var DoctorUpdate = await _DoctorRepository.UpdateAsync(Doctor);
            var resultUpdateDto = _mapper.Map<DoctorUpdateDto>(DoctorUpdate);

            return new SuccessDataResult<DoctorUpdateDto>(resultUpdateDto, Messages.Updated);
        }
    }
}
