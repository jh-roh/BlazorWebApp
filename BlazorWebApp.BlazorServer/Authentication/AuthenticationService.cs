using BlazorWebApp.BlazorServer.Models;
using BlazorWebApp.BlazorServer.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWebApp.BlazorServer.Authentication
{
    public class AuthenticationService
    {
        private readonly UserService _userService;

        private readonly ProtectedLocalStorage _protectedLocalStorage;

        private const string UserStorageKey = "blg_user";

        private JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public AuthenticationService(UserService userService, ProtectedLocalStorage protectedLocalStorage)
        {
            _userService = userService;
            _protectedLocalStorage = protectedLocalStorage;
        }

        public async Task<LoggedInUser?> GetUserAsync(LoginModel loginModel)
        {
            var loggedInUser = await _userService.LoginAsync(loginModel);

            if(loggedInUser is not null)
            {
                await SaveUserToBrowserStorageAsync(loggedInUser);
            }

            return loggedInUser;

        }

        public async Task SaveUserToBrowserStorageAsync(LoggedInUser? user)
          => await _protectedLocalStorage.SetAsync(UserStorageKey, JsonSerializer.Serialize(user,_jsonSerializerOptions));

        public async Task<LoggedInUser?> GetUserFromBrowserStorageAsync()
        {
            try
            {
                var result = await _protectedLocalStorage.GetAsync<string>(UserStorageKey);
                if (result.Success && !string.IsNullOrWhiteSpace(result.Value))
                { 
                    return JsonSerializer.Deserialize<LoggedInUser>(result.Value, _jsonSerializerOptions);
                }
            }
            catch (System.Exception ex)
            {
                //Eat out this exception
                //as we know this will occur when this method is being called from server
                //where there is no browser and localstroage
                //don't worry about this, as this will be called from client side(browser's  side)  after this
                //so we will have the data there
                //so we are good to ignore this exception
            }

            return null;
        }

        public async Task RemoveUserFromBrowserStorageAsync()
            => await _protectedLocalStorage.DeleteAsync(UserStorageKey);
    }
}
