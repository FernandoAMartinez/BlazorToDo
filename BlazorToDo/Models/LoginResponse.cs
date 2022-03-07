using System.Text.Json.Serialization;

namespace BlazorToDo.Models;

public class LoginResponse
{
    [JsonPropertyName("userId")] public string UserId { get; set; }
    [JsonPropertyName("jwt")] public string JWT { get; set; }

}
