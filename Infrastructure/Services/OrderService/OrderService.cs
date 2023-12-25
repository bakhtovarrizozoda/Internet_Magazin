using System.Net;
using AutoMapper;
using Domain.Dtos.Order;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public OrderService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetOrderFullInfoDto>> GetOrderFullInfo()
    {
        var result = await (
            from o in _context.Orders
            join c in _context.Customers on o.CustomerId equals c.Id into contorder
            from co in contorder.DefaultIfEmpty()
            select new GetOrderFullInfoDto()
            {
                Id = o.Id,
                OrderPlaced = o.OrderPlaced,
                OrderFulFilled = o.OrderFulFilled,
                FirstName = co.FirstName,
                LastName = co.LastName,
                CustomerId = o.CustomerId
            }).ToListAsync();
        return result;
    }

    public async Task<Response<List<GetOrderDto>>> GetOrder()
    {
        try
        {
            var model = _context.Orders.ToList();
            var result = _mapper.Map<List<GetOrderDto>>(model);
            return new Response<List<GetOrderDto>>(result);

        }
        catch (Exception e)
        {
            return new Response<List<GetOrderDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOrderDto>> GetOrderById(int id)
    {
        try
        {
            var model = await _context.Orders.FindAsync(id);
            if (model == null) return new Response<GetOrderDto>(new GetOrderDto());
            var result = _mapper.Map<GetOrderDto>(model);
            return new Response<GetOrderDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOrderDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOrderDto>> AddOrder(AddOrderDto order)
    {
        try
        {
            var orderCreate = new Orders
            {
             CustomerId = order.CustomerId,
             OrderPlaced = order.OrderPlaced,
             OrderFulFilled = order.OrderFulFilled
            };
            await _context.Orders.AddAsync(orderCreate);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetOrderDto>(orderCreate);
            return new Response<GetOrderDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOrderDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
    
    public async Task<Response<GetOrderDto>> UpdateOrder(AddOrderDto order)
    {
        try
        {
            var find = await _context.Orders.FindAsync(order.Id);
            _mapper.Map(order, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetOrderDto>(find);
            return new Response<GetOrderDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOrderDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteOrder(int id)
    {
        try
        {
            var find = await _context.Orders.FindAsync(id);
            if (find == null) return new Response<bool>(false);
            _context.Orders.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}