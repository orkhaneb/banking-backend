namespace Customer.Models.Entities
{
    public class CustomerEntity:Base
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; } = 50;
        public int UserId { get; set; }

    }
}
