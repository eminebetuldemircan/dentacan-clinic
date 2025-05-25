using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.DoctorDtos;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings.DoctorMapping
{
    public class DoctorProfile : Profile
    {

        public DoctorProfile()
        {
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<Doctor, DoctorCreateDto>();

            CreateMap<DoctorUpdateDto, Doctor>();
            CreateMap<Doctor, DoctorUpdateDto>();

            CreateMap<DoctorListDto, Doctor>();
            CreateMap<Doctor, DoctorListDto>();

            CreateMap<DoctorDetailDto, Doctor>();
            CreateMap<Doctor, DoctorDetailDto>();
        }
    }
}
