using InnowisePet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Storage.DAL.Data;

public class StorageDbContext : DbContext
{
    public StorageDbContext(DbContextOptions<StorageDbContext> options) : base(options)
    { }

    public DbSet<StorageModel> Storages { get; set; }
    public DbSet<ProductStorageModel> ProductStorages { get; set; }
}