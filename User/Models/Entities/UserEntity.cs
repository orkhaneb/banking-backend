using User.Models.Entities;

namespace User.Models.Entities
{
    public class UserEntity:Base
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
