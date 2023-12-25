using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.ProductService;

public interface IFileService
{
    Task<string> CreateFileAsync(string folder,IFormFile file);
    bool DeleteFile(string folder, string filename);
}