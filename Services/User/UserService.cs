using CinePass_be.DTOS;
using CinePass_be.Models;
using CinePass_be.Repositories;

namespace CinePass_be.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<List<User>> GetAllUsersAsync()
  {
    return await _userRepository.GetAllUsersAsync();
  }

  public async Task<User?> GetByEmailAsync(string email)
  {
    return await _userRepository.GetByEmailAsync(email);
  }

  public async Task<User?> GetByUsernameAsync(string username)
  {
    return await _userRepository.GetByUsernameAsync(username);
  }

  public async Task<User> CreateUserAsync (CreateUserDto userDto)
  {
    // Valid request
    // Create new user
    var user = new User
    {
      Username = userDto.Username,
      Email = userDto.Email,
      PasswordHash = userDto.PasswordHash,
      Bio = userDto.Bio,
      AvatarUrl = userDto.AvatarUrl,
      Role = userDto.Role,
      IsActive = userDto.IsActive,
      FollowerCount = 0,
      FollowingCount = 0,
      ReviewCount = 0,
    };

    return await _userRepository.CreateUserAsync(user);
  }

}
