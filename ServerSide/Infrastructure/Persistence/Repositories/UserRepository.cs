using Infrastructure.Persistence.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    protected readonly MeditDBContext _dbContext;

    public UserRepository(MeditDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetIdByUserName(string userName)
    {
        return await _dbContext.Users
                     .Where(i => i.UserName == userName)
                     .Select(i => i.Id)
                     .FirstOrDefaultAsync();
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task<bool> IsRefreshTokenValid(string refreshToken)
    {
        var tokenInUser = await _dbContext.Users.AnyAsync(x => x.RefreshToken == refreshToken);
        return tokenInUser;
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> CheckUserNameExistAsync(string userName)
    => _dbContext.Users.AnyAsync(x => x.UserName == userName);

    public Task<bool> CheckEmailExistAsync(string email)
    => _dbContext.Users.AnyAsync(x => x.Email == email);
}
