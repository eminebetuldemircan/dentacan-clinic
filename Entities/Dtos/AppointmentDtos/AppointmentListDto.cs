using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.AppointmentDtos
{
    public class AppointmentListDto
    {
        public int Id { get; set; }
        public string Date { get; set; } // Gün
        public string Time { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string TCId { get; set; }
        public string DoctorName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string NoteMessage { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ServiceTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsVerification { get; set; }
        public string IsVerificationName { get; set; }

    }
}
