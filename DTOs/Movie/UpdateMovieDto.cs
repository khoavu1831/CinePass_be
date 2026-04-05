namespace CinePass_be.DTOs;

public class UpdateMovieDto
{
  public string? LocalTitle { get; set; }
  public string? Description { get; set; }
  public string? Director { get; set; }
  public string? Cast { get; set; }
  public bool? IsActive { get; set; } = true;
}