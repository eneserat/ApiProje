namespace ApiProje.WebApi.DTOs.ContactDTOs
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public string MapLocation { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
    }
}
