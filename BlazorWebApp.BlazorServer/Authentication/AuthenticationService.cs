using BlazorWebApp.BlazorServer.Models;
using BlazorWebApp.BlazorServer.Services;
using System.Threading.Tasks;

namespace BlazorWebApp.BlazorServer.Authentication
{
    public class AuthenticationService
    {
        private readonly UserService _userService;

        public AuthenticationService(UserService userService)
        {
            _userService = userService;
        }

        public async Task<LoggedInUser?> GetUserAsync(LoginModel loginModel)
        {
            var loggedInUser = await _userService.LoginAsync(loginModel);

            return loggedInUser;

        }
    }
}
