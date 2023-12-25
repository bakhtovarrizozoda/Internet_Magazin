using Domain.Dtos.Category;
using Domain.Dtos.Product;
using Domain.Wrapper;

namespace Infrastructure.Services.CategoryService;

public interface ICategoryService
{
    public Task<Response<List<GetCategoryDto>>> GetCategory();
    public Task<Response<GetCategoryDto>> GetCategoryById(int id);
    public Task<Response<GetCategoryDto>> AddCategory(AddCategoryDto category);
    public Task<Response<GetCategoryDto>> UpdateCategory(AddCategoryDto category);
    public Task<Response<bool>> DeleteCategory(int id);
}