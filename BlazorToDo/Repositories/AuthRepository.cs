using BlazorToDo.Models;
using System.Net.Http.Json;

namespace BlazorToDo.Repositories;
public class AuthRepository : IAuthRepository
{
    public AuthRepository(HttpClient client)
    {
        _client = client;
    }

    private readonly HttpClient _client;

    public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
    {
        var response = await _client.PostAsJsonAsync("/auth/login", request);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            //TODO: Add reference to athentication provider
            return result;
        }
        else
        {
            return null;
        }
    }

    public async Task RegisterUserAsync(RegisterRequest request)
    {
        var response = await _client.PostAsJsonAsync("/auth/register", request);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
        }
    }
}
