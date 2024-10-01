
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository 
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            var users = _context.Users.AsQueryable();
            return await users.Skip(pageNumber - 1).Take(pageSize).ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<User> AddAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }
        public async Task<User?> UpdateAsync(int id, AddUserDto addUserDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user == null) 
            {
                return null;
            }

            user.Name = addUserDto.Name;
            user.Email = addUserDto.Email;
            user.Salary = addUserDto.Salary;

            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user == null) 
            {
                return null;
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }

}