using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Customers
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required, MaxLength(50)]
    public string Addres { get; set; }
    [Required, MaxLength(50)]
    public string Phone { get; set; }
    [Required, MaxLength(50)]
    public string Email { get; set; }

    
    public List<Orders> Orders { get; set; }
}