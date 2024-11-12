// MonProjet.Application/Services/UserService.cs
using MonProjet.Core.Entities;
using MonProjet.Core.Interfaces;
using MonProjet.Application.Interfaces;

namespace MonProjet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(Guid id) => await _userRepository.GetUserByIdAsync(id);

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userRepository.GetAllUsersAsync();

        public async Task AddUserAsync(User user) => await _userRepository.AddUserAsync(user);

        public async Task UpdateUserAsync(User user) => await _userRepository.UpdateUserAsync(user);

        public async Task DeleteUserAsync(Guid id) => await _userRepository.DeleteUserAsync(id);
    }
}
