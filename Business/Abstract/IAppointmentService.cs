using Core.Results;
using Entities.Dtos.AppointmentDtos;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        Task<IResult> AddAsync(AppointmentCreateDto entity);
        Task<IDataResult<IEnumerable<AppointmentListDto>>> GetListAsync(Expression<Func<Appointment, bool>> filter = null);
        Task<IDataResult<AppointmentDetailDto>> GetAsync(Expression<Func<Appointment, bool>> filter);

        Task<IDataResult<AppointmentDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<AppointmentUpdateDto>> UpdateAsync(AppointmentUpdateDto AppointmentUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);

        Task<IDataResult<bool>> VerificationByIdAsync(int id, string verificationCode);

        Task<IDataResult<bool>> ChangeAppointmentAsync(string token);
    }

   
}
