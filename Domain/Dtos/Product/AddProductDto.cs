
using Microsoft.AspNetCore.Http;

namespace Domain.Dtos.Product;

public class AddProductDto : ProductBaseDto
{
    public IFormFile File { get; set; }
}