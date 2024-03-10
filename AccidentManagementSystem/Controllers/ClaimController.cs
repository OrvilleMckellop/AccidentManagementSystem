using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.Claim;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AccidentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IClaim _claimRepo;

        public ClaimController(AppDbContext context, IClaim claimRepo)
        {
            _context = context;
            _claimRepo = claimRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claim = await _claimRepo.GetAllClaimAsync();
            var claimDto = claim.Select(c => c.ToClaimDto());

            return Ok(claim);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var claim = await _claimRepo.GetClaimByIdAsync(id);

            return claim == null ? NotFound() : Ok(claim.ToClaimDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClaimDto createClaimDto)
        {
            var claim = createClaimDto.ToCreateClaim();
            await _claimRepo.CreateClaimAsync(claim);

            return CreatedAtAction(nameof(GetById), new { id = claim.ClaimID }, claim.ToClaimDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ClaimDto claimDto)
        {
            var claim = await _claimRepo.UpdateClaimAsync(id, claimDto);
            return claim == null ? NotFound() : Ok(claim.ToClaimDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var claim = await _claimRepo.DeleteClaimAsync(id);

            return claim == null ? NotFound() : Ok(claim.ToClaimDto());
        }

    }
}