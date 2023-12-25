using Infrastructure.AutomapperProfile;
using Infrastructure.Context;
using Infrastructure.Services.CategoryService;
using Infrastructure.Services.CustomerService;
using Infrastructure.Services.OrderDetailService;
using Infrastructure.Services.OrderService;
using Infrastructure.Services.ProductService;
using Infrastructure.Services.UserService;
using Microsoft.EntityFrameworkCore;
using WebApi.ExstensionMethods.AuthConfiguration;
using WebApi.ExtensionMethods.RegisterService;
using WebApi.ExtensionMethods.SwaggerConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRegisterService(builder.Configuration);
builder.Services.SwaggerService();
builder.Services.AddAuthConfigureService(builder.Configuration);


var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ServiceProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
