using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Customers> Customers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<User> Users { get; set; }
}