namespace Domain.Dtos.Product;

public class ProductBaseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime TermStart { get; set; }
    public DateTime TermFinish { get; set; }
    public int Discount { get; set; }
    public int CategoryId { get; set; }
}