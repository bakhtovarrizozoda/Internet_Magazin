using Domain.Dtos.Order;
using Infrastructure.Services.OrderService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService service)
    {
        _orderService = service;
    }

    [HttpGet("GetOrderFullInfo")]
    public async Task<IActionResult> GetOrderFullInfo()
    {
        var result = await _orderService.GetOrderFullInfo();
        return Ok(result);
    }

    [HttpGet("GetOrder")]
    public async Task<IActionResult> GetOrder()
    {
        var result = await _orderService.GetOrder();
        return Ok(result);
    }

    [HttpGet("GetOrderById")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var result = await _orderService.GetOrderById(id);
        return Ok(result);
    }

    [HttpPost("AddOrder")]
    public async Task<IActionResult> AddOrder(AddOrderDto order)
    {
        var result = await _orderService.AddOrder(order);
        return Ok(result);
    }

    [HttpPut("UpdateOrder")]
    public async Task<IActionResult> UpdateOrder(AddOrderDto order)
    {
        var result = await _orderService.UpdateOrder(order);
        return Ok(result);
    }

    [HttpDelete("DeleteOrder")]
    public async Task<IActionResult> DeleteOrder([FromQuery]int id)
    {
        var result = await _orderService.DeleteOrder(id);
        return Ok(result);
    }
}