using BlazorToDo.Models;

namespace BlazorToDo.Repositories;

public interface IAuthRepository
{
    Task RegisterUserAsync(RegisterRequest request);
    Task<LoginResponse> LoginUserAsync(LoginRequest request);
}