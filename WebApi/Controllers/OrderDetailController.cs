using Domain.Dtos.OrderDetail;
using Infrastructure.Services.OrderDetailService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _service;

    public OrderDetailController(IOrderDetailService service)
    {
        _service = service;
    }

    [HttpGet("GetOrderDetailFullInfo")]
    public async Task<IActionResult> GetOrderDetailFullInfo()
    {
        var result = await _service.GetOrderDetailFullInfo();
        return Ok(result);
    }
    
    [HttpGet("GetOrderDetail")]
    public async Task<IActionResult> GetOrderDetail()
    {
        var result = await _service.GerOrderDetail();
        return Ok(result);
    }

    [HttpGet("GetOrderDetailById")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var result = await _service.GetOrderDetailById(id);
        return Ok(result);
    }

    [HttpPost("AddOrderDetail")]
    public async Task<IActionResult> AddOrderDetail([FromQuery]AddOrderDetailDto orderDetail)
    {
        var result = await _service.AddOrderDetail(orderDetail);
        return Ok(result);
    }

    [HttpPut("UpdateOrderDetail")]
    public async Task<IActionResult> UpdateOrderDetail(AddOrderDetailDto orderDetail)
    {
        var result = await _service.UpdateOrderDetail(orderDetail);
        return Ok(result);
    }

    [HttpDelete("DeleteOrderDetail")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        var result = await _service.DeleteOrderDetail(id);
        return Ok(result);
    }
}