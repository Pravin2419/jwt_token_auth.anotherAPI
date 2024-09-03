using jwt_token_auth.anotherAPI.Models;

namespace jwt_token_auth.anotherAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
        Task<bool> AddUserAsync(User user);
    }
}
