using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Domain.Entities;

public class Orders
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime OrderPlaced { get; set; }
    [Required] 
    public DateTime OrderFulFilled { get; set; }
    [Required]
    public int CustomerId { get; set; }
    
    public List<OrderDetail> OrderDetail { get; set; }
    [NotMapped]
    public Customers Customers { get; set; }
}