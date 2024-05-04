using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table(name: "tb_m_products")]
    public class Product : BaseEntity
    {
        [Column(name: "name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(name: "description")]
        public string Description  { get; set; }
        [Column(name: "price")]
        public decimal Price { get; set; }
        [Column(name: "product_brand_id")]
        public int ProductBrandId { get; set; }
        [Column(name: "product_category_id")]
        public int ProductCategoryId { get; set;}
        [Column(name: "created_date")]
        public DateTime CreatedDate { get; set;}
        [Column(name: "modified_date")]
        public DateTime ModifiedDate { get; set;}

        // // Cardinality
        public ProductBrand ProductBrand { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}