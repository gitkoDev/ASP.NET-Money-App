using System.ComponentModel.DataAnnotations;

namespace api.Dtos;

public class AddUserDto
{
    [Required]
    [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 symbols")]
    public string Name { get; set; } = "";
    [MaxLength(30, ErrorMessage = "Email cannot be longer than 30 symbols")]
    public string? Email { get; set; }
    public decimal Salary { get; set;} 
}
