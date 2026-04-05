using System.Text.Json.Serialization;

namespace CinePass_be.DTOs;

public class TmdbCastMember
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("character")]
    public string Character { get; set; } = string.Empty;

    [JsonPropertyName("order")]
    public int Order { get; set; }
}