namespace Domain.Dtos.OrderDetail;

public class GetOrderDetailFullInfoDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
}