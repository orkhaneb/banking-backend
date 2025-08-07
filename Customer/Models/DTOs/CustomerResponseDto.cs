namespace Customer.Models.DTOs
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
