using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace TcPlatWebApp.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null || HasSessionExpired(userSession))
                    return new AuthenticationState(_anonymous);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Role, userSession.Role)
                };

                // Check if password is present and add to claims
                if (!string.IsNullOrEmpty(userSession.Password))
                {
                    Console.WriteLine($"Password loaded: {userSession.Password}");  // Debugging output
                    claims.Add(new Claim("password", userSession.Password));
                }
                else
                {
                    Console.WriteLine("Password is missing or empty");
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));
                return new AuthenticationState(claimsPrincipal);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving authentication state: {ex.Message}");
                return new AuthenticationState(_anonymous);
            }
        }

        private bool HasSessionExpired(UserSession userSession)
        {
            return DateTime.UtcNow > userSession.SessionStartTime.AddDays(30);
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                userSession.SessionStartTime = DateTime.UtcNow;
                await _sessionStorage.SetAsync("UserSession", userSession);

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "CustomAuth"));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task Logout()
        {
            await _sessionStorage.DeleteAsync("UserSession");
            var claimsPrincipal = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
