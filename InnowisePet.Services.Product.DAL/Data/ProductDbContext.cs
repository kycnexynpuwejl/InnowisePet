using InnowisePet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Product.DAL.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
}