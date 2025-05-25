namespace Entities.Dtos.DoctorDtos
{
    public class DoctorCreateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; } // e.g. Dr., Prof.
        public string Specialization { get; set; } // e.g. Cardiology, Neurology    

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
