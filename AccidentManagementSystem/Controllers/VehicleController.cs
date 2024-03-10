using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.Vehicle;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AccidentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IVehicle _vehicleRepo;

        public VehicleController(AppDbContext context, IVehicle vehicleRepo)
        {
            _context = context;
            _vehicleRepo = vehicleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicle = await _vehicleRepo.GetAllVehiclesAsync();
            var vehicleDto = vehicle.Select(v => v.ToVehicleDto());

            return Ok(vehicle);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicle = await _vehicleRepo.GetVehicleByIdAsync(id);

            return vehicle == null ? NotFound() : Ok(vehicle.ToVehicleDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleDto createVehicleDto)
        {
            var vehicle = createVehicleDto.ToCreateVehicle();
            await _vehicleRepo.CreateVehicleAsync(vehicle);

            return CreatedAtAction(nameof(GetById), new { id = vehicle.VehicleID }, vehicle.ToVehicleDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] VehicleDto updateVehicleDto)
        {
            var vehicle = await _vehicleRepo.UpdateVehicleAsync(id, updateVehicleDto);

            return vehicle == null ? NotFound() : Ok(vehicle.ToVehicleDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var vehicle = await _vehicleRepo.DeleteVehicleAsync(id);

            return vehicle == null ? NotFound() : NoContent();
        }

    }
}