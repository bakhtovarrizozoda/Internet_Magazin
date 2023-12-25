namespace Domain.Dtos.Product;

public class GetProductFullInfoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime TermStart { get; set; }
    public DateTime TermFinish { get; set; }
    public int Discount { get; set; }
    public string FileName { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
}