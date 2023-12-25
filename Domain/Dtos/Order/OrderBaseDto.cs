namespace Domain.Dtos.Order;

public class OrderBaseDto
{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFulFilled { get; set; }
    public int CustomerId { get; set; }
}