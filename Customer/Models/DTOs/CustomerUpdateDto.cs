namespace Customer.Models.DTOs
{
    public class CustomerUpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

    }
}
