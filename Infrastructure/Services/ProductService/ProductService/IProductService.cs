using Domain.Dtos.Product;
using Domain.Wrapper;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    public Task<List<GetProductFullInfoDto>> GetProductFullInfo();
    public Task<Response<List<GetProductDto>>> GetProduct();
    public Task<Response<GetProductDto>> GetProductById(int id);
    public Task<Response<GetProductDto>> AddProduct(AddProductDto product);
    public Task<Response<GetProductDto>> UpdateProduct(AddProductDto product);
    public Task<Response<bool>> DeleteProduct(int id);
}