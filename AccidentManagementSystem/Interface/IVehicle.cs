using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.Vehicle;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Interface
{
    public interface IVehicle
    {
        Task<List<Vehicle>> GetAllUsersAsync();
        Task<Vehicle> GetUserByIdAsync(int id);
        Task<Vehicle> CreateUserAsync(Vehicle vehicle);
        Task<Vehicle?> UpdateUserAsync(int id, VehicleDto vehicleDto);
        Task<Vehicle?> DeleteUserAsync(int id);
    }
}