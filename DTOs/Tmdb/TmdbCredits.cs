using System.Text.Json.Serialization;

namespace CinePass_be.DTOs;

public class TmdbCredits
{
    [JsonPropertyName("cast")]
    public List<TmdbCastMember> Cast { get; set; } = [];

    [JsonPropertyName("crew")]
    public List<TmdbCrewMember> Crew { get; set; } = [];
}