using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;
using Questeloper.Domain.Repositories;

namespace Questeloper.Infrastructure.Persistence.Repositories;

internal class UserRepository(QuesteloperDbContext questeloperDbContext) : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id) => 
        await questeloperDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<User>> GetUsersAsync() => 
        await questeloperDbContext.Users.ToListAsync();
}