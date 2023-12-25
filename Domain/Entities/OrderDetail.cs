using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [NotMapped]
    public Products Products { get; set; }
    [NotMapped]
    public Orders Orders { get; set; }
}