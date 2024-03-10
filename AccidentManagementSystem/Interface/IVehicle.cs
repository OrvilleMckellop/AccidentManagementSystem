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
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle?> GetVehicleByIdAsync(int id);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task<Vehicle?> UpdateVehicleAsync(int id, VehicleDto VehicleDto);
        Task<Vehicle?> DeleteVehicleAsync(int id);
    }
}