using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.Accident;
using AccidentManagementSystem.Dtos.Vehicle;

namespace AccidentManagementSystem.Models
{
    public static class AccidentMapper
    {
        public static AccidentDto ToAccidenDto(this Accident accidentModel)
        {
            return new AccidentDto
            {
                AccidentID = accidentModel.AccidentID,
                Date = accidentModel.Date,
                Time = accidentModel.Time,
                Location = accidentModel.Location,
                Description = accidentModel.Location,
                Severity = accidentModel.Severity,
                VehicleID = accidentModel.VehicleID
            };
        }

        public static Accident ToCreateAccident(this CreateAccidentDto createAccidentDto)
        {
            return new Accident
            {
                Date = createAccidentDto.Date,
                Time = createAccidentDto.Time,
                Location = createAccidentDto.Location,
                Description = createAccidentDto.Location,
                Severity = createAccidentDto.Severity,
                VehicleID = createAccidentDto.VehicleID
            };
        }
    }
}