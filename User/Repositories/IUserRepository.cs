using User.Models.Entities;

namespace User.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByEmailAsync(string email);
        Task AddAsync(UserEntity user);

    }
}
