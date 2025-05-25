using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.ContactUsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings.ContactUsMapping
{
    public class ContactUsProfile : Profile
    {

        public ContactUsProfile()
        {
            CreateMap<ContactUsCreateDto, ContactUs>();
            CreateMap<ContactUs, ContactUsCreateDto>();

            CreateMap<ContactUsListDto, ContactUs>();
            CreateMap<ContactUs, ContactUsListDto>();

            CreateMap<ContactUsDetailDto, ContactUs>();
            CreateMap<ContactUs, ContactUsDetailDto>();
        }
    }
}
