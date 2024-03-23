using Questeloper.Domain.Entities;

namespace Questeloper.Domain.Repositories;

public interface IUserRepository
{
    public Task CreateUserAsync(User user);
    public Task<User?> GetByIdAsync(int id);
    public bool IsExists(string email, string nickName);
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task CompleteAsync();
}