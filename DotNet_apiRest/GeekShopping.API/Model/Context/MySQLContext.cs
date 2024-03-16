using Microsoft.EntityFrameworkCore;

namespace GeekShopping.API.Model.Context;

public class MySqlContext(DbContextOptions<MySqlContext> options) : DbContext(options) {
    public DbSet<Product> Products { get; set; }
}