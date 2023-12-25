using System.Net;
using AutoMapper;
using Domain.Dtos.Product;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public ProductService(DataContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<List<GetProductFullInfoDto>> GetProductFullInfo()
    {
        var result = await (
            from p in _context.Products
            join c in _context.Category on p.CategoryId equals c.Id into prodcategory
            from pc in prodcategory.DefaultIfEmpty()
            select new GetProductFullInfoDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price - (p.Price * p.Discount / 100),
                TermStart = p.TermStart,
                TermFinish = p.TermFinish,
                Discount = p.Discount,
                CategoryName = pc.CategoryName,
                FileName = p.FileName,
                CategoryId = p.CategoryId
            }).ToListAsync();
        return result;
    }

    public async Task<Response<List<GetProductDto>>> GetProduct()
    {
        try
        {
            var model = _context.Products.ToList();
            var result = _mapper.Map<List<GetProductDto>>(model);
            return new Response<List<GetProductDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetProductDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetProductDto>> GetProductById(int id)
    {
        try
        {
            var model = await _context.Products.FindAsync(id);
            if (model == null) return new Response<GetProductDto>(new GetProductDto());
            var result = _mapper.Map<GetProductDto>(model);
            return new Response<GetProductDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetProductDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetProductDto>> AddProduct(AddProductDto product)
    {
        try
        {
            DateTime productTermStartUtc = DateTime.SpecifyKind(product.TermStart, DateTimeKind.Utc);
            product.TermStart = DateTime.UtcNow;
            DateTime productTermFinishUtc = DateTime.SpecifyKind(product.TermFinish, DateTimeKind.Utc);
            product.TermFinish = DateTime.UtcNow;
            var filename = await _fileService.CreateFileAsync("images", product.File);
            var productEntity = new Products()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                TermStart = product.TermStart,
                TermFinish = product.TermFinish,
                Discount = product.Discount,
                FileName = product.File.FileName,
                CategoryId = product.CategoryId
            };
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetProductDto>(productEntity);
            return new Response<GetProductDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetProductDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetProductDto>> UpdateProduct(AddProductDto product)
    {
        try
        {
            DateTime productTermStartUtc = DateTime.SpecifyKind(product.TermStart, DateTimeKind.Utc);
            product.TermStart = DateTime.UtcNow;
            DateTime productTermFinishUtc = DateTime.SpecifyKind(product.TermFinish, DateTimeKind.Utc);
            product.TermFinish = DateTime.UtcNow;
            var model = await _context.Products.FindAsync(product.Id);
            if (model == null)
            {
                return null;
            }

            if (product.File != null)
            {
                if (model.FileName != null)
                {
                    _fileService.DeleteFile("images", model.FileName);
                }

                var filename = await _fileService.CreateFileAsync("images", product.File);
                model.FileName = filename;
            }

            model.Id = product.Id;
            model.Name = product.Name;
            model.Price = product.Price;
            model.TermStart = product.TermStart;
            model.TermFinish = product.TermFinish;
            model.Discount = product.Discount;
            model.FileName = product.File.FileName;
            model.CategoryId = product.CategoryId;
            
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetProductDto>(model);
            return new Response<GetProductDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetProductDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteProduct(int id)
    {
        try
        {
            var model = await _context.Products.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}