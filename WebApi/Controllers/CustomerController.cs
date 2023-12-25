using Domain.Dtos.Customers;
using Domain.Wrapper;
using Infrastructure.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet("GetCustomer")]
    public async Task<IActionResult> GetCustomer()
    {
        var result = await _service.GetCustomer();
        return Ok(result);
    }

    [HttpGet("GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var result = await _service.GetCustomerById(id);
        return Ok(result);
    }

    [HttpPost("AddCustomer")]
    public async Task<IActionResult> AddCustomer([FromQuery]AddCustomerDto customer)
    {
        var result = await _service.AddCustomer(customer);
        return Ok(result);
    }

    [HttpPut("UpdateCustomer")]
    public async Task<IActionResult> UpdateCustomer([FromQuery] AddCustomerDto customer)
    {
        var result = await _service.UpdateCustomer(customer);
        return Ok(result);
    }

    [HttpDelete("DeleteCustomer")]
    public async Task<IActionResult> DeleteCustomer([FromQuery]int id)
    {
        var result = await _service.DeleteCustomer(id);
        return Ok(result);
    }
}