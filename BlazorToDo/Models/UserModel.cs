using System.Text.Json.Serialization;

namespace BlazorToDo.Models;
public class UserModel
{
    public UserModel() { Id = new Guid(); }
    [JsonPropertyName("_id")] public Guid Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonIgnore] [JsonPropertyName("password")] public string Password { get; set; }
    //[JsonPropertyName("lastJWT")] public string LastJWT { get; set; }
}