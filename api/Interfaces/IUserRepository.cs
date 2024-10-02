using api.Dtos;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(int pageNumber, int pageSize);
        Task<User?> GetByIdAsync(int id);
        Task<User> AddAsync(User userModel);
        Task<User?> UpdateAsync(int id, AddUserDto addUserDto);
        Task<User?> DeleteAsync(int id); 

    }
}

