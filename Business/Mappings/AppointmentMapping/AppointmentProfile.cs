using AutoMapper;
using Entities.Dtos.AppointmentDtos;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Mappings.AppointmentMapping  
{
    public class AppointmentProfile : Profile
    {

        public AppointmentProfile()
        {
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<Appointment, AppointmentCreateDto>();

            CreateMap<AppointmentUpdateDto, Appointment>();
            CreateMap<Appointment, AppointmentUpdateDto>();

            CreateMap<AppointmentListDto, Appointment>();
            CreateMap<Appointment, AppointmentListDto>();

            CreateMap<AppointmentDetailDto, Appointment>();
            CreateMap<Appointment, AppointmentDetailDto>();
        }
    }
}
