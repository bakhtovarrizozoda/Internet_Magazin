namespace Domain.Dtos.Order;

public class GetOrderFullInfoDto
{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFulFilled { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CustomerId { get; set; }
}