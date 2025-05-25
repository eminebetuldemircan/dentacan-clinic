using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.ContactUsDtos;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactUsService : IContactUsService
    {
        IContactUsRepository _ContactUsRepository;
        IMapper _mapper;
        public ContactUsService(IContactUsRepository ContactUsRepository, IMapper mapper)
        {
            _ContactUsRepository = ContactUsRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(ContactUsCreateDto entity)
        {
            var newContactUs = _mapper.Map<ContactUs>(entity);

            await _ContactUsRepository.AddAsync(newContactUs);


            return new SuccessResult(Messages.Added);
        }

        public async Task<IDataResult<bool>> DeleteAsync(int id)
        {
            var isDelete = await _ContactUsRepository.DeleteAsync(id);
            return new SuccessDataResult<bool>(isDelete, Messages.Deleted);
        }

        public async Task<IDataResult<ContactUsDetailDto>> GetAsync(Expression<Func<ContactUs, bool>> filter)
        {
            var ContactUs = await _ContactUsRepository.GetAsync(filter);
            if (ContactUs != null)
            {
                var ContactUsDetailDto = _mapper.Map<ContactUsDetailDto>(ContactUs);
                return new SuccessDataResult<ContactUsDetailDto>(ContactUsDetailDto, Messages.Listed);

            }
            return new ErrorDataResult<ContactUsDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<ContactUsDetailDto>> GetByIdAsync(int id)
        {
            var ContactUs = await _ContactUsRepository.GetAsync(x => x.Id == id);
            if (ContactUs != null)
            {
                var ContactUsDetailDto = _mapper.Map<ContactUsDetailDto>(ContactUs);
                return new SuccessDataResult<ContactUsDetailDto>(ContactUsDetailDto, Messages.Listed);
            }
            return new ErrorDataResult<ContactUsDetailDto>(null, Messages.NotListed);
        }

        public async Task<IDataResult<IEnumerable<ContactUsListDto>>> GetListAsync(Expression<Func<ContactUs, bool>> filter = null)
        {
            if (filter == null)
            {
                // Exception 
                //throw new UnauthorizedAccessException("UnAuthorized"); 
                var response = await _ContactUsRepository.GetListAsync();
                var responseDetailDto = _mapper.Map<IEnumerable<ContactUsListDto>>(response);
                return new SuccessDataResult<IEnumerable<ContactUsListDto>>(responseDetailDto, Messages.Listed);
            }
            else
            {
                var response = await _ContactUsRepository.GetListAsync(filter);
                var responseDetailDto = _mapper.Map<IEnumerable<ContactUsListDto>>(response);
                return new SuccessDataResult<IEnumerable<ContactUsListDto>>(responseDetailDto, Messages.Listed);
            }
        }

     
    }
}
