using Core.Results;
using Entities.Concrete;
using Entities.Dtos.DoctorDtos;
using System.Linq.Expressions;


namespace Business.Abstract
{
    public interface IDoctorService
    {
        Task<IResult> AddAsync(DoctorCreateDto entity);


        Task<IDataResult<IEnumerable<DoctorListDto>>> GetListAsync(Expression<Func<Doctor, bool>> filter = null);
        Task<IDataResult<DoctorDetailDto>> GetAsync(Expression<Func<Doctor, bool>> filter);

        Task<IDataResult<DoctorDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<DoctorUpdateDto>> UpdateAsync(DoctorUpdateDto DoctorUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
