using jwt_token_auth.anotherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace jwt_token_auth.anotherAPI.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly filedetailsContext _context;

        public UserRepository(filedetailsContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);

          
           return await _context.SaveChangesAsync() >0;
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
           return await _context.Users.SingleOrDefaultAsync(u=>u.Username== username && u.Password== password);
        }
    }
    
}
