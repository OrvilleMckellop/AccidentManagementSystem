using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.Accident;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AccidentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccidentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAccident _accidentRepo;

        public AccidentController(AppDbContext context, IAccident accidentRepo)
        {
            _context = context;
            _accidentRepo = accidentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accident = await _accidentRepo.GetAllAccidentAsync();
            var accidentDto = accident.Select(a => a.ToAccidenDto());

            return Ok(accident);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var accident = await _accidentRepo.GetAccidentByIdAsync(id);

            return accident == null ? NotFound() : Ok(accident.ToAccidenDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccidentDto createAccidentDto)
        {
            var accident = createAccidentDto.ToCreateAccident();
            await _accidentRepo.CreateAccidentAsync(accident);

            return CreatedAtAction(nameof(GetById), new { id = accident.AccidentID }, accident.ToAccidenDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AccidentDto accidentDto)
        {
            var accident = await _accidentRepo.UpdateAccidentAsync(id, accidentDto);

            return accident == null ? NotFound() : Ok(accident.ToAccidenDto());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var accident = await _accidentRepo.DeleteAccidentAsync(id);

            return accident == null ? NotFound() : NoContent();
        }
    }
}