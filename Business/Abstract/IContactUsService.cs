using Core.Results;
using Entities.Concrete;
using Entities.Dtos.ContactUsDtos;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactUsService
    {
        Task<IResult> AddAsync(ContactUsCreateDto entity);


        Task<IDataResult<IEnumerable<ContactUsListDto>>> GetListAsync(Expression<Func<ContactUs, bool>> filter = null);
        Task<IDataResult<ContactUsDetailDto>> GetAsync(Expression<Func<ContactUs, bool>> filter);

        Task<IDataResult<ContactUsDetailDto>> GetByIdAsync(int id);

        Task<IDataResult<bool>> DeleteAsync(int id);
    }
}
