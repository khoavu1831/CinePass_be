using System.Text.Json.Serialization;

namespace CinePass_be.DTOs;

public class TmdbVideos
{
    [JsonPropertyName("results")]
    public List<TmdbVideo> Results { get; set; } = [];
}