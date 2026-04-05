namespace CinePass_be.DTOs;

public class AdminFetchMoviesRequestDto
{
  public string? Type { get; set; } // "popular", "top_rated", "upcoming", "now_playing"
  public int GenreId { get; set; } = 0; // For fetching by genre
  public string? SortBy { get; set; } = "popularity.desc"; // For discover endpoint
  public int Page { get; set; } = 1;
  public int PageSize { get; set; } = 20; // How many to fetch and save from TMDB
  public string Region { get; set; } = "US";
}