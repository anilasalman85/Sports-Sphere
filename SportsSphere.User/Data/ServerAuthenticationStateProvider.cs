using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SportsSphere.User.Data
{
    // ServerAuthenticationStateProvider.cs
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Implement logic to retrieve user authentication state from your authentication service
            // For simplicity, you can use a sample implementation

            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, "user@example.com"),
            // Add other claims as needed
        }, "YourAuthenticationScheme");

            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }
    }

}
