using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.Claim;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AccidentManagementSystem.Repository
{
    public class ClaimRepository : IClaim
    {
        private readonly AppDbContext _context;

        public ClaimRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Claim>> GetAllClaimAsync()
        {
            return await _context.Claims.ToListAsync();
        }

        public async Task<Claim?> GetClaimByIdAsync(int id)
        {
            return await _context.Claims.FindAsync(id);
        }
        public async Task<Claim> CreateClaimAsync(Claim claimModel)
        {
            await _context.Claims.AddAsync(claimModel);
            await _context.SaveChangesAsync();

            return claimModel;
        }

        public async Task<Claim?> DeleteClaimAsync(int id)
        {
            var claimModel = await _context.Claims.FirstOrDefaultAsync(claim => claim.ClaimID == id);

            if (claimModel == null)
            {
                return null;
            }

            _context.Claims.Remove(claimModel);
            await _context.SaveChangesAsync();

            return claimModel;
        }

        public async Task<Claim?> UpdateClaimAsync(int id, ClaimDto claimDto)
        {
            var exsitingClaim = await _context.Claims.FirstOrDefaultAsync(claim => claim.ClaimID == id);

            if (exsitingClaim == null)
            {
                return null;
            }

            exsitingClaim.DateFiled = claimDto.DateFiled;
            exsitingClaim.Description = claimDto.Description;
            exsitingClaim.Status = claimDto.Status;
            exsitingClaim.Amount = claimDto.Amount;
            exsitingClaim.AccidentID = claimDto.AccidentID;

            return exsitingClaim;
        }
    }
}