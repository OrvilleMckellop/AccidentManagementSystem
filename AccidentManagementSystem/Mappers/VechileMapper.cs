using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.User;
using AccidentManagementSystem.Dtos.Vehicle;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Mappers
{
    public static class VechileMapper
    {
        public static VehicleDto ToVehicleDto(this Vehicle vehicleModel)
        {
            return new VehicleDto
            {
                VehicleID = vehicleModel.VehicleID,
                Make = vehicleModel.Make,
                Model = vehicleModel.Model,
                Year = vehicleModel.Year,
                RegistrationNumber = vehicleModel.RegistrationNumber,
                UserID = vehicleModel.UserID
            };
        }

        public static Vehicle ToCreateVehicle(this CreateVehicleDto createVehicleDto)
        {
            return new Vehicle
            {
                Make = createVehicleDto.Make,
                Model = createVehicleDto.Model,
                Year = createVehicleDto.Year,
                RegistrationNumber = createVehicleDto.RegistrationNumber,
                UserID = createVehicleDto.UserID
            };
        }
    }
}