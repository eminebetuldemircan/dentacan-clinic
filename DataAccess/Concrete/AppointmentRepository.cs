using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AppointmentRepository : EfBaseRepository<Appointment, ApplicationDbContext>, IAppointmentRepository
    {
        public async Task<bool> VerificationByIdAsync(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var VerficationEntity = await context.Set<Appointment>().FindAsync(id);
 
                VerficationEntity.IsVerification = true;             
                var data = await context.SaveChangesAsync();
                if (data > 0)
                {
                    return true;
                }
                return false;

            }
        }
    }
}
