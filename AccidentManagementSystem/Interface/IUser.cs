using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.User;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Interface
{
    public interface IUser
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User userModel);
        Task<User?> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task<User?> DeleteUserAsync(int id);
    }
}