namespace CinePass_be.DTOs;

public class BatchOperationResultDto
{
  public int SuccessCount { get; set; }
  public int FailureCount { get; set; }
  public List<string>? Errors { get; set; } = [];
  public List<MovieResponseDto>? SavedMovies { get; set; } = [];
}
