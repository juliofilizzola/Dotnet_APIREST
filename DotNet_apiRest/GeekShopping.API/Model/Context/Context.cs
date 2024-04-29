using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API.Model.Context;

public class Context(DbContextOptions<Context> options) : DbContext(options) {
    public DbSet<Product>           Products          { get; set; }
    public DbSet<Category>          Category          { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category {
                Name = "TEC",
                Id = 1,
                Code = "XAS123"
            }
        );
    }
}