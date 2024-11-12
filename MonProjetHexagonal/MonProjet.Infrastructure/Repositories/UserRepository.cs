using MonProjet.Core.Entities;
using MonProjet.Core.Interfaces;
using MongoDB.Driver;
using MonProjet.Infrastructure.Data;

namespace MonProjet.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(MongoDbContext dbContext)
        {
            _usersCollection = dbContext.GetCollection<User>("Users");
        }

        public async Task AddUserAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

    }
}
