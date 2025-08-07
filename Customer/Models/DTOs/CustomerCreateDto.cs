namespace Customer.Models.DTOs
{
    public class CustomerCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }
    }
}
