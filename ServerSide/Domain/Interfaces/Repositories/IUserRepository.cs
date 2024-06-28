using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<int> GetIdByUserName(string userName);
    Task<User> GetUserByUsernameAsync(string username);
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> IsRefreshTokenValid(string  refreshToken);
    Task UpdateAsync(User user);
    Task CreateAsync(User user);
    //Task Delete(User user);
    Task<bool> CheckUserNameExistAsync(string userName);
    Task<bool> CheckEmailExistAsync(string email);
}
