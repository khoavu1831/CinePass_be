using CinePass_be.DTOS;
using CinePass_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinePass_be;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserAsync()
    {
        try
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest("loi get list: " + e);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        try
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Loi: " + ex.Message });
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        try
        {
            // Get userId from JWT
            var userIdClaim = User.FindFirst("userId")?.Value ??
                User.FindFirst("sub")?.Value;

            if (!int.TryParse(userIdClaim, out var currentUserId))
                return Unauthorized(new { message = "Token khong hop le" });

            if (currentUserId != id)
                return Forbid("Chi duoc sua profile chinh minh");

            var result = await _userService.UpdateUserAsync(id, updateUserDto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Loi: " + ex.Message });
        }
    }
}
