using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.User;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AccidentManagementSystem.Repository
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(user => user.UserID == id);

            if (userModel == null)
            {
                return null;
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var exsitingUser = await _context.Users.FirstOrDefaultAsync(user => user.UserID == id);

            if (exsitingUser == null)
            {
                return null;
            }

            exsitingUser.Username = userDto.Username;
            exsitingUser.Password = userDto.Password;
            exsitingUser.Email = userDto.Email;

            await _context.SaveChangesAsync();

            return exsitingUser;
        }
    }
}
