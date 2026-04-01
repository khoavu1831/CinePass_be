using CinePass_be.DTOS;
using CinePass_be.Models;

namespace CinePass_be.Services;

public interface IUserService
{
  Task<List<User>> GetAllAsync();
  Task<UserResponseDto> GetByIdAsync(int id);
  Task<UserResponseDto> GetByEmailAsync(string email);
  Task<UserResponseDto> GetByUsernameAsync(string username);
}
