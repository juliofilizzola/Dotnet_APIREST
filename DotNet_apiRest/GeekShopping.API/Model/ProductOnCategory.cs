namespace GeekShopping.API.Model;

public class ProductOnCategory {
    public long     ProductId { get; set; }
    public Product Product   { get; set; }

    // Chave estrangeira para a Category
    public long      CategoryId { get; set; }
    public Category Category   { get; set; }
}