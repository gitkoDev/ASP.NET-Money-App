using api.Dtos;
using api.Models;

namespace api.Mappers;

public static class UserMapper
{
    public static User ToUserDto(this AddUserDto addUserDto)
    {
        return new(){
            Name = addUserDto.Name,
            Email = addUserDto.Email,
            Salary = addUserDto.Salary
        };
    }
}