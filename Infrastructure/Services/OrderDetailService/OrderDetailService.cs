using System.Net;
using AutoMapper;
using Domain.Dtos.OrderDetail;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.OrderDetailService;

public class OrderDetailService : IOrderDetailService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public OrderDetailService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<List<GetOrderDetailFullInfoDto>> GetOrderDetailFullInfo()
    {
        var result = await (
            from od in _context.OrderDetails
            join p in _context.Products on od.ProductId equals p.Id into orderdetailprod
            from odp in orderdetailprod.DefaultIfEmpty()
            select new GetOrderDetailFullInfoDto()
            {
                Id = od.Id,
                Quantity = od.Quantity,
                OrderId = od.OrderId,
                Name = odp.Name,
                ProductId = od.ProductId,
                Price = odp.Price * od.Quantity
            }).ToListAsync();
        return result;
    }

    public async Task<Response<List<GetOrderDetailDto>>> GerOrderDetail()
    {
        try
        {
            var model = _context.OrderDetails.ToList();
            var result = _mapper.Map<List<GetOrderDetailDto>>(model);
            return new Response<List<GetOrderDetailDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetOrderDetailDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOrderDetailDto>> GetOrderDetailById(int id)
    {
        try
        {
            var model = await _context.OrderDetails.FindAsync(id);
            if (model == null) return new Response<GetOrderDetailDto>(new GetOrderDetailDto());
            var result = _mapper.Map<GetOrderDetailDto>(model);
            return new Response<GetOrderDetailDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOrderDetailDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOrderDetailDto>> AddOrderDetail(AddOrderDetailDto orderDetail)
    {
        try
        {
            var model = _mapper.Map<OrderDetail>(orderDetail);
            await _context.OrderDetails.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetOrderDetailDto>(model);
            return new Response<GetOrderDetailDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOrderDetailDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetOrderDetailDto>> UpdateOrderDetail(AddOrderDetailDto orderDetail)
    {
        try
        {
            var model = await _context.OrderDetails.FindAsync(orderDetail.Id);
            _mapper.Map(orderDetail, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetOrderDetailDto>(model);
            return new Response<GetOrderDetailDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetOrderDetailDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteOrderDetail(int id)
    {
        try
        {
            var model = await _context.OrderDetails.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.OrderDetails.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}