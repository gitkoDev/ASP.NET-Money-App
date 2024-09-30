using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class AddUserDto
{
    public string Name { get; set; } = "";
    public string? Email { get; set; }
    public decimal Salary { get; set;} 
}
