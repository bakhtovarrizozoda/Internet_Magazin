using Domain.Dtos.Order;
using Domain.Dtos.OrderDetail;
using Domain.Wrapper;

namespace Infrastructure.Services.OrderService;

public interface IOrderService
{
    public Task<List<GetOrderFullInfoDto>> GetOrderFullInfo();
    public Task<Response<List<GetOrderDto>>> GetOrder();
    public Task<Response<GetOrderDto>> GetOrderById(int id);
    public Task<Response<GetOrderDto>> AddOrder(AddOrderDto order);
    public Task<Response<GetOrderDto>> UpdateOrder(AddOrderDto order);
    public Task<Response<bool>> DeleteOrder(int id);
}