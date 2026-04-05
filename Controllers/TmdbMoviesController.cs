using CinePass_be.Clients.Tmdb;
using CinePass_be.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinePass_be.Controllers
{
  [Route("api/tmdb")]
  [ApiController]
  public class TmdbMoviesController : ControllerBase
  {
    private readonly IMovieService _movieService;
    private readonly ITmdbClient _tmdbClient;

    public TmdbMoviesController(IMovieService movieService, ITmdbClient tmdbClient)
    {
      _movieService = movieService;
      _tmdbClient = tmdbClient;
    }

    [HttpGet("movies/search")]
    public async Task<IActionResult> SearchAsync([FromQuery] string query, [FromQuery] int page = 1)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(query))
          return BadRequest(new { message = "Query không được để trống" });

        var results = await _movieService.SearchAndFetchFromTmdbAsync(query, page);
        return Ok(new { data = results, total = results.Count });
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = "Lỗi: " + ex.Message });
      }
    }

    [HttpGet("genres")]
    public async Task<IActionResult> GetGenresAsync()
    {
      try
      {
        var genres = await _tmdbClient.GetGenresAsync();

        if (genres == null)
          return BadRequest(new { message = "Không thể lấy danh sách genres từ TMDB" });

        return Ok(genres);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = "Lỗi: " + ex.Message });
      }
    }
  }
}
