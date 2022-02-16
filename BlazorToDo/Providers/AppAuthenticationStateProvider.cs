using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorToDo.Providers;
public class AppAuthenticationStateProvider : AuthenticationStateProvider
{
    public AppAuthenticationStateProvider(/*IAuthRepository authRepository*/)
    {

    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}

