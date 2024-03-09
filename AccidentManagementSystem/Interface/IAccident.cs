using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.Accident;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Interface
{
    public interface IAccident
    {
        Task<List<Accident>> GetAllUsersAsync();
        Task<Accident> GetUserByIdAsync(int id);
        Task<Accident> CreateUserAsync(Accident accident);
        Task<Accident?> UpdateUserAsync(int id, AccidentDto accidentDto);
        Task<Accident?> DeleteUserAsync(int id);
    }
}