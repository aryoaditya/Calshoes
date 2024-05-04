using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table(name: "tb_m_product_variants")]
    public class ProductVariant : BaseEntity
    {
        [Column(name: "size")]
        public decimal Size { get; set; }
        [Column(name: "color", TypeName = "nvarchar(50)")]
        public string Color { get; set; }
        [Column(name: "stock_quantity")]
        public int StockQuantity { get; set; }
        [Column(name:"product_id")]
        public int ProductId { get; set; }

        // Cardinality
        public Product Product { get; set; }
    }
}