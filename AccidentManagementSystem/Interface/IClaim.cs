using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.Claim;

namespace AccidentManagementSystem.Interface
{
    public interface IClaim
    {
        Task<List<ClaimDto>> GetAllUsersAsync();
        Task<ClaimDto> GetUserByIdAsync(int id);
        Task<ClaimDto> CreateUserAsync(ClaimDto claimDto);
        Task<ClaimDto> UpdateUserAsync(int id, ClaimDto claimDto);
        Task<bool> DeleteUserAsync(int id);
    }
}