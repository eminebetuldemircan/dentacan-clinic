using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppointmentChangeToken : BaseEntity
    {
        public string Token { get; set; }
        public string EmptyAppointmentDate { get; set; }
        public string EmptyAppointmentTime { get; set; }
        public int OldAppointmentId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsUsed { get; set; } = false;

    }
}
