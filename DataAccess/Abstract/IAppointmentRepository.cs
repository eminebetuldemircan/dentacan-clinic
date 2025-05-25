using Core;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<bool> VerificationByIdAsync(int id);
    }
}
