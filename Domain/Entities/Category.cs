using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; }

    public List<Products> Products { get; set; }
}