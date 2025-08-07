using User.Helper;
using User.Models;
using User.Models.DTOs;
using User.Models.Entities;
using User.Repositories;

namespace User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly JwtTokenGenerator _jwtGenerator;

        public UserService(JwtTokenGenerator jwtGenerator, IUserRepository userRepository)
        {
            _jwtGenerator = jwtGenerator;
            _repository = userRepository;
        }


        public async Task<UserResponseDto> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _repository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Bu email ilə artıq istifadəçi mövcuddur.");

            var hashedPassword = PasswordHasher.Hash(dto.PasswordHash);

            var user = new UserEntity
            {
                Email = dto.Email,
                PasswordHash = hashedPassword
            };

            await _repository.AddAsync(user);

            return new UserResponseDto
            {
                Email = user.Email,
                Token = _jwtGenerator.GenerateToken(user)
            };
        }

        public async Task<UserResponseDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _repository.GetByEmailAsync(dto.Email);
            if (user == null || !PasswordHasher.Verify(dto.PasswordHash, user.PasswordHash))
                throw new Exception("Email və ya şifrə yanlışdır.");

            return new UserResponseDto
            {
                Id=user.Id,
                Email = user.Email,
                Token = _jwtGenerator.GenerateToken(user)
            };
        }

    }
}
