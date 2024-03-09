using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentManagementSystem.Dtos.User;
using AccidentManagementSystem.Models;

namespace AccidentManagementSystem.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserID = userModel.UserID,
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                RoleID = userModel.RoleID
            };
        }

        public static User ToUserFromCreateDto(this CreateUserDto createUserDto)
        {
            return new User
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                Email = createUserDto.Email,
                RoleID = createUserDto.RoleID
            };
        }
    }
}