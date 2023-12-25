using Domain.Dtos.Customers;
using Domain.Wrapper;

namespace Infrastructure.Services.CustomerService;

public interface ICustomerService
{
    public Task<Response<List<GetCustomerDto>>> GetCustomer();
    public Task<Response<GetCustomerDto>> GetCustomerById(int id);
    public Task<Response<GetCustomerDto>> AddCustomer(AddCustomerDto customer);
    public Task<Response<GetCustomerDto>> UpdateCustomer(AddCustomerDto customer);
    public Task<Response<bool>> DeleteCustomer(int id);
}    