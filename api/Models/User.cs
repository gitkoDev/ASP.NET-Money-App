using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace api.Models;

public class User
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public string? Email { get; set; }

    public decimal Salary { get; set;} 
}


