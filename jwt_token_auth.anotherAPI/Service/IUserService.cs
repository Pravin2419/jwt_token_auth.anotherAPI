//using jwt_token_auth.anotherAPI.Controllers.controllers;
using jwt_token_auth.anotherAPI.Models;

namespace jwt_token_auth.anotherAPI.Service
{
    public interface IUserService
    {

        Task<AuthenticateResponse> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(User user);
    }
}
