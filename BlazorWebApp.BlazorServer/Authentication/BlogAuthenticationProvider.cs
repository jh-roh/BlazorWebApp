using BlazorWebApp.BlazorServer.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BlazorWebApp.BlazorServer.Authentication
{
    public class BlogAuthenticationProvider : AuthenticationStateProvider, IDisposable
    {
        private const string BlogAuthenticationType = "blog-auth";
        private readonly AuthenticationService _authenticationService;
        public LoggedInUser LoggedInUser{ get; private set; } = new LoggedInUser(0, string.Empty);

        public BlogAuthenticationProvider(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            AuthenticationStateChanged += BlogAuthenticationProvider_AuthenticationStateChanged;
        }

        public static ClaimsPrincipal GetClaimsFromUser(LoggedInUser? user)
        {
            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user?.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user?.DisplayName == null ? string.Empty : user?.DisplayName)
                }, BlogAuthenticationType);

            return new(identity);
        }


        private async void BlogAuthenticationProvider_AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authState = await task;

            if(authState is not null)
            {
                var userId = authState.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var displayName = authState.User.FindFirstValue(ClaimTypes.Name);
                
                if(userId is not null && displayName is not null)
                {
                    LoggedInUser = new(int.Parse(userId), displayName);
                }
                else
                {
                    LoggedInUser = new LoggedInUser(0, string.Empty);
                }
            }

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            
            var user = await _authenticationService.GetUserFromBrowserStorageAsync();
            var claimsPrincipal = new ClaimsPrincipal();

            if (user is not null)
            {
               claimsPrincipal = GetClaimsFromUser(user);
            }
            return new AuthenticationState(claimsPrincipal);

        }

        public async Task<string?> LoginAsync(LoginModel loginModel)
        {
            var loggedInUser = await _authenticationService.GetUserAsync(loginModel);

            if(loggedInUser is null)
            {
                return "Invalid credentials";   
            }
            var authState = new AuthenticationState(GetClaimsFromUser(loggedInUser));
            NotifyAuthenticationStateChanged(Task.FromResult(authState));

            return null;
        }

        public async Task LogoutAsync()
        {
            await _authenticationService.RemoveUserFromBrowserStorageAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }

        public void Dispose() => 
            AuthenticationStateChanged -= BlogAuthenticationProvider_AuthenticationStateChanged;
    }
}
