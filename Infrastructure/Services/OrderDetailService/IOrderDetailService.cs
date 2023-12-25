using Domain.Dtos.OrderDetail;
using Domain.Wrapper;

namespace Infrastructure.Services.OrderDetailService;

public interface IOrderDetailService
{
    public Task<List<GetOrderDetailFullInfoDto>> GetOrderDetailFullInfo();
    public Task<Response<List<GetOrderDetailDto>>> GerOrderDetail();
    public Task<Response<GetOrderDetailDto>> GetOrderDetailById(int id);
    public Task<Response<GetOrderDetailDto>> AddOrderDetail(AddOrderDetailDto orderDetail);
    public Task<Response<GetOrderDetailDto>> UpdateOrderDetail(AddOrderDetailDto orderDetail);
    public Task<Response<bool>> DeleteOrderDetail(int id);
}