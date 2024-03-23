using Microsoft.EntityFrameworkCore;
using Questeloper.Domain.Entities;
using Questeloper.Domain.Repositories;

namespace Questeloper.Infrastructure.Persistence.Repositories;

internal class UserRepository(QuesteloperDbContext questeloperDbContext) : IUserRepository
{
    public async Task CreateUserAsync(User user) =>
        await questeloperDbContext.Users.AddAsync(user);

    public async Task<User?> GetByIdAsync(int id) => 
        await questeloperDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    public bool IsExists(string email, string nickName) => 
            questeloperDbContext.Users.AsEnumerable().Any(x => 
                x.EmailAddress.Value.Equals(email) || x.NickName.Value.Equals(nickName));

    public async Task<IEnumerable<User>> GetUsersAsync() => 
        await questeloperDbContext.Users.ToListAsync();
    
    public async Task CompleteAsync() => 
        await questeloperDbContext.SaveChangesAsync();
}