using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.API.Model.Base;

namespace GeekShopping.API.Model;

[Table("category")]
public class Category : BaseEntity {
    [Column("name")]
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Column("code")]
    [Required]
    [StringLength(100)]
    public string Code { get; set; }

    public virtual ICollection<ProductOnCategory> ProductCategories { get; set; }
}