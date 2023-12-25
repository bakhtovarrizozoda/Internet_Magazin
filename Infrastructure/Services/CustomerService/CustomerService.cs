using System.Net;
using AutoMapper;
using Domain.Dtos.Customers;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;


namespace Infrastructure.Services.CustomerService;

public class CustomerService : ICustomerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CustomerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<GetCustomerDto>>> GetCustomer()
    {
        try
        {
            var model = _context.Customers.ToList();
            var result = _mapper.Map<List<GetCustomerDto>>(model);
            return new Response<List<GetCustomerDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetCustomerDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetCustomerDto>> GetCustomerById(int id)
    {
        try
        {
            var find = await _context.Customers.FindAsync(id);
            if (find == null) return new Response<GetCustomerDto>(new GetCustomerDto());
            var result = _mapper.Map<GetCustomerDto>(find);
            return new Response<GetCustomerDto>(result);

        }
        catch (Exception e)
        {
            return new Response<GetCustomerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetCustomerDto>> AddCustomer(AddCustomerDto customer)
    {
        try
        {
            var model = _mapper.Map<Customers>(customer);
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetCustomerDto>(model);
            return new Response<GetCustomerDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetCustomerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetCustomerDto>> UpdateCustomer(AddCustomerDto customer)
    {
        try
        {
            var find = await _context.Customers.FindAsync(customer.Id);
            _mapper.Map(customer, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetCustomerDto>(find);
            return new Response<GetCustomerDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetCustomerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteCustomer(int id)
    {
        try
        {
            var find = await _context.Customers.FindAsync(id);
            if (find == null) return new Response<bool>(false);
            _context.Customers.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}