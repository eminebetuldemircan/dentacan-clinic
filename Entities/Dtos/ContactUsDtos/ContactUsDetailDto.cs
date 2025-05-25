namespace Entities.Dtos.ContactUsDtos
{
    public class ContactUsDetailDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; } // e.g. Dr., Prof.
        public string Specialization { get; set; } // e.g. Cardiology, Neurology    

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
