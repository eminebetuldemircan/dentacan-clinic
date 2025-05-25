using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Doctor : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; } // e.g. Dr., Prof.
        public string Specialization { get; set; } // e.g. Cardiology, Neurology    

        public string PhoneNumber { get; set; }
        public string Email { get; set; }  
    }
}
