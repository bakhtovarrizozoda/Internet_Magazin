using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [Required, MaxLength(50)]
    public string LastName { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Email { get; set; } = null!;
    [Required, MaxLength(13)]
    public string Phone { get; set; } = null!;
    [Required, MaxLength(50)]
    public string UserName { get; set; } = null!;
    [Required]
    public string HashPassword { get; set; } = null!;
    [Required]
    public bool IsBlocked { get; set; } = false!;
}
