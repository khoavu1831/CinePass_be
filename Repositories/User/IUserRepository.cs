using CinePass_be.DTOS;
using CinePass_be.Models;

namespace CinePass_be.Repositories;

public interface IUserRepository
{
  Task<List<User>> GetAllUsersAsync();
  Task<User?> GetByEmailAsync(string email);
  Task<User?> GetByUsernameAsync(string username);
  Task<User> CreateUserAsync(User user);

}
