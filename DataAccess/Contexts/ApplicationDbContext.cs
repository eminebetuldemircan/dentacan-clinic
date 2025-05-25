using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using OnlineRandevuSistemi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=OnlineDentalAppointment;Trusted_Connection=true");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Todo : Appointment için entity configurationlarını 

            // Your other entity configurations...

            base.OnModelCreating(modelBuilder);
        }

        //Todo : Controllerlada admin olanlar area admin içine atılacak 
        // Todo : UserControllerlar yazılacak 
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<AppointmentChangeToken> AppointmentChangeTokens { get; set; }
    }
}
