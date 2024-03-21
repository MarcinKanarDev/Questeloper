using Questeloper.Domain.Entities;

namespace Questeloper.Domain.Repositories;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(int id);
    public Task<IEnumerable<User>> GetUsersAsync();
}