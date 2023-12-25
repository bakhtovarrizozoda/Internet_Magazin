using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Products
{
    [Key] 
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public DateTime TermStart { get; set; }
    [Required]
    public DateTime TermFinish { get; set; }
    [Required]
    public int Discount { get; set; }
    [Required] 
    public string FileName { get; set; }
    [Required]
    public int CategoryId { get; set; }

    public List<OrderDetail> OrderDetail { get; set; }
    [NotMapped]
    public Category Category { get; set; }
}