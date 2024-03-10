using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.Claim;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Interface
{
    public interface IClaim
    {
        Task<List<Claim>> GetAllClaimAsync();
        Task<Claim?> GetClaimByIdAsync(int id);
        Task<Claim> CreateClaimAsync(Claim claimModel);
        Task<Claim?> UpdateClaimAsync(int id, ClaimDto claimDto);
        Task<Claim?> DeleteClaimAsync(int id);
    }
}