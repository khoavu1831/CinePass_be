namespace CinePass_be;

public class UpdateUserDto
{
  public string? Username { get; set; }
  public string? Bio { get; set; }
  public string? AvatarUrl { get; set; }
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}