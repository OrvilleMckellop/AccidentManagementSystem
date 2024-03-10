using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.Vehicle;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AccidentManagementSystem.Repository
{
    public class VehicleRepository : IVehicle
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }
        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task<Vehicle?> DeleteVehicleAsync(int id)
        {
            var vehicleModel = await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.VehicleID == id);

            if (vehicleModel == null)
            {
                return null;
            }

            _context.Vehicles.Remove(vehicleModel);
            await _context.SaveChangesAsync();

            return vehicleModel;
        }
        public async Task<Vehicle?> UpdateVehicleAsync(int id, VehicleDto vehicleDto)
        {
            var exsitingVehicle = await _context.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.VehicleID == id);

            if (exsitingVehicle == null)
            {
                return null;
            }

            exsitingVehicle.Make = vehicleDto.Make;
            exsitingVehicle.Model = vehicleDto.Model;
            exsitingVehicle.Year = vehicleDto.Year;
            exsitingVehicle.RegistrationNumber = vehicleDto.RegistrationNumber;
            exsitingVehicle.UserID = vehicleDto.UserID;

            await _context.SaveChangesAsync();

            return exsitingVehicle;
        }
    }
}