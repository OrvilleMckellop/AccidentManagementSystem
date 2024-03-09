using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.Accident;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AccidentManagementSystem.Repository
{
    public class AccidentRepository : IAccident
    {

        private readonly AppDbContext _context;

        public AccidentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Accident>> GetAllUsersAsync()
        {
            return await _context.Accidents.ToListAsync();
        }

        public async Task<Accident> GetUserByIdAsync(int id)
        {
            return await _context.Accidents.FindAsync(id);
        }
        public async Task<Accident> CreateUserAsync(Accident accident)
        {
            await _context.Accidents.AddAsync(accident);
            await _context.SaveChangesAsync();

            return accident;
        }

        public async Task<Accident?> DeleteUserAsync(int id)
        {
            var accidentModel = await _context.Accidents.FirstOrDefaultAsync(accident => accident.AccidentID == id);

            if (accidentModel == null)
            {
                return null;
            }

            _context.Remove(accidentModel);
            await _context.SaveChangesAsync();
            return accidentModel;
        }

        public async Task<Accident?> UpdateUserAsync(int id, AccidentDto accidentDto)
        {
            var exsitingAccident = await _context.Accidents.FirstOrDefaultAsync(accident => accident.AccidentID == id);

            if (exsitingAccident == null)
            {
                return null;
            }

            exsitingAccident.Date = accidentDto.Date;
            exsitingAccident.Time = accidentDto.Time;
            exsitingAccident.Location = accidentDto.Location;
            exsitingAccident.Description = accidentDto.Description;
            exsitingAccident.Severity = accidentDto.Severity;
            exsitingAccident.VehicleID = accidentDto.VehicleID;

            return exsitingAccident;
        }
    }
}