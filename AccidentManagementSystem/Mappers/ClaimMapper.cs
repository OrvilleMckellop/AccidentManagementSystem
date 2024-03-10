using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.Claim;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Mappers
{
    public static class ClaimMapper
    {
        public static ClaimDto ToClaimDto(this Claim claimModel)
        {
            return new ClaimDto
            {
                ClaimID = claimModel.ClaimID,
                DateFiled = claimModel.DateFiled,
                Status = claimModel.Status,
                Amount = claimModel.Amount,
                AccidentID = claimModel.AccidentID
            };
        }

        public static Claim ToCreateClaim(this CreateClaimDto createClaimDto)
        {
            return new Claim
            {
                DateFiled = createClaimDto.DateFiled,
                Status = createClaimDto.Status,
                Amount = createClaimDto.Amount,
                AccidentID = createClaimDto.AccidentID
            };
        }
    }
}