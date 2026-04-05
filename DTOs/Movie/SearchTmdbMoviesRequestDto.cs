namespace CinePass_be.DTOs;

public class SearchTmdbMoviesRequestDto
{
  public string Query { get; set; } = string.Empty;
  public int Page { get; set; } = 1;
}
