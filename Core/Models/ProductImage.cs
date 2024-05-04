using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table(name: "tb_m_product_images")]
    public class ProductImage : BaseEntity
    {
        [Column(name:"image_url", TypeName = "nvarchar(100)")]
        public string ImageUrl { get; set; }
        [Column(name:"product_id")]
        public int ProductId { get; set; }

        // Cardinality
        public Product Product { get; set; }
    }
}