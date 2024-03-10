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
        Task<List<Accident>> GetAllAccidentAsync();
        Task<Accident?> GetAccidentByIdAsync(int id);
        Task<Accident> CreateAccidentAsync(Accident accident);
        Task<Accident?> UpdateAccidentAsync(int id, AccidentDto accidentDto);
        Task<Accident?> DeleteAccidentAsync(int id);
    }
}