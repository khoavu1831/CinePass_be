using System.Text.Json.Serialization;

namespace CinePass_be.DTOs;

public class TmdbGenre
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;
}