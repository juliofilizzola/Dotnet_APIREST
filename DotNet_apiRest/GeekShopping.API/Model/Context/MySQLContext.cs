using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API.Model.Context;

public class MySqlContext(DbContextOptions<MySqlContext> options) : DbContext(options) {
    public DbSet<Product>           Products          { get; set; }
    public DbSet<Category>          Category          { get; set; }
    public DbSet<ProductOnCategory> ProductOnCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração do relacionamento muitos para muitos entre Product e Category
        modelBuilder.Entity<ProductOnCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<ProductOnCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductOnCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId);

        modelBuilder.Entity<Category>().HasData(
                new Category {
                    Name = "TEC",
                    Id = 1,
                    Code = "XAS123"
                }
            );
    }


}