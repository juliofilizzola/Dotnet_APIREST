using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.API.Model.Base;

namespace GeekShopping.API.Model;

[Table("product")]
public class Product: BaseEntity {
    [Column("name")]
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Column("price")]
    [Required]
    [Range(1, 1000000)]
    public decimal Price { get; set; }

    [Column("description")]
    [StringLength(5000)]
    public string Description { get; set; }

    [Column("category_name")]
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }

    [Column("image_url")]
    [StringLength(300)]
    public string ImageUrl { get; set; }

    public virtual ICollection<ProductOnCategory> ProductCategories { get; set; }
}