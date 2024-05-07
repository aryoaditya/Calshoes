using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table(name: "tb_m_product_brands")]
    public class ProductBrand : BaseEntity
    {
        [Column(name: "name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        // Cardinality
        public ICollection<Product> Product { get; set; }
    }
}