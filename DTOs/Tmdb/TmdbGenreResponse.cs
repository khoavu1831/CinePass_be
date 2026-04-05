using System.Text.Json.Serialization;

namespace CinePass_be.DTOs;

public class TmdbGenreResponse
{
  [JsonPropertyName("genres")]
  public List<TmdbGenre> Genres { get; set; } = [];
}