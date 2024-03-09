using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Data;
using AccidentManagementSystem.Dtos.User;
using AccidentManagementSystem.Interface;
using AccidentManagementSystem.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AccidentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUser _userRepo;

        public UserController(AppDbContext context, IUser userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepo.GetAllUsersAsync();
            var userDto = user.Select(u => u.ToUserDto());
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
        {
            var user = userDto.ToUserFromCreateDto();
            await _userRepo.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = user.UserID }, user.ToUserDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userRepo.UpdateUserAsync(id, updateUserDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userRepo.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}