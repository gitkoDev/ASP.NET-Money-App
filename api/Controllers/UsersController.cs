using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _user_repository;
    public UsersController(IUserRepository userRepository)
    {
        _user_repository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, int pageSize = 10)
    {
        var users = await _user_repository.GetAllAsync(pageNumber, pageSize);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _user_repository.GetByIdAsync(id);
        if (user == null) 
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddUserDto addUserDto)
    {
        var userModel = addUserDto.ToUserDto();
        var result = await _user_repository.AddAsync(userModel);

        return CreatedAtAction(nameof(GetById), new { id = userModel.Id}, userModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(AddUserDto addUserDto, [FromRoute] int id)
    {
        var user = await _user_repository.UpdateAsync(id, addUserDto);

        if (user == null) 
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = await _user_repository.DeleteAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return NoContent();
    }
    
}

