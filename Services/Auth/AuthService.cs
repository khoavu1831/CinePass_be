using CinePass_be.DTOS;
using CinePass_be.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CinePass_be.Services;

public class AuthService : IAuthService
{
  private readonly IUserRepository _userRepository;

  public AuthService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
  {
    throw new NotImplementedException();
    
  }

  public async Task<AuthResponseDto> ResigterAsync(RegisterRequestDto request)
  {
    // Valid request
    var username = request.Username;
    var existingUsername = await _userRepository.GetByUsernameAsync(username);
    if (existingUsername != null) 
      throw new Exception("ok");

    var email = request.Email;
    var password = request.Password;
    // Hash pass
    // Create key
    // Return response
    return new AuthResponseDto
    {
      AccessToken = ""
    };
  }
}

