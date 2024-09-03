
using jwt_token_auth.anotherAPI.Models;
using jwt_token_auth.anotherAPI.Repository;
using jwt_token_auth.anotherAPI.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService;

    public UserService(IUserRepository userRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthenticateResponse> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);

        if (user == null)
            return null;

        var token = _tokenService.GenerateToken(user.Username);
        //return new AuthenticateResponse(user, token);
        return new AuthenticateResponse(user, token);
    }

    public async Task<bool> RegisterAsync(User user)
    {
        if (await _userRepository.GetUserByUsernameAndPasswordAsync(user.Username, user.Password) != null)
            return false;

        return await _userRepository.AddUserAsync(user);
    }
}
