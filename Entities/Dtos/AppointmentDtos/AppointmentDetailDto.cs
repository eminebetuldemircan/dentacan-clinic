using Entities.Enums;

namespace Entities.Dtos.AppointmentDtos
{
    public class AppointmentDetailDto
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
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }

        public bool IsVerification { get; set; }
    }
}
