using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table(name: "tb_m_product_categories")]
    public class ProductCategory : BaseEntity
    {
        [Column(name: "name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}