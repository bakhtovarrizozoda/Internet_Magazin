namespace Domain.Dtos.OrderDetail;

public class OrderDetailBaseDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}