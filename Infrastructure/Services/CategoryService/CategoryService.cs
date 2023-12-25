using System.Net;
using AutoMapper;
using Domain.Dtos.Category;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CategoryService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<GetCategoryDto>>> GetCategory()
    {
        try
        {
            var model = await _context.Category.ToListAsync();
            var result = _mapper.Map<List<GetCategoryDto>>(model);
            return new Response<List<GetCategoryDto>>(result);
        }
        catch (Exception e)
        {
            return new Response<List<GetCategoryDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetCategoryDto>> GetCategoryById(int id)
    {
        try
        {
            var model = await _context.Category.FindAsync(id);
            if (model == null) return new Response<GetCategoryDto>(new GetCategoryDto());
            var result = _mapper.Map<GetCategoryDto>(model);
            return new Response<GetCategoryDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetCategoryDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetCategoryDto>> AddCategory(AddCategoryDto category)
    {
        try
        {
            var model = _mapper.Map<Category>(category);
            await _context.Category.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetCategoryDto>(model);
            return new Response<GetCategoryDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetCategoryDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetCategoryDto>> UpdateCategory(AddCategoryDto category)
    {
        try
        {
            var model = await _context.Category.FindAsync(category.Id);
            _mapper.Map(category, model);
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetCategoryDto>(model);
            return new Response<GetCategoryDto>(result);
        }
        catch (Exception e)
        {
            return new Response<GetCategoryDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteCategory(int id)
    {
        try
        {
            var model = await _context.Category.FindAsync(id);
            if (model == null) return new Response<bool>(false);
            _context.Category.Remove(model);
            await _context.SaveChangesAsync();
            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}