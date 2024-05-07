namespace API.Dtos
{
    public class ProductReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime ModifiedDate { get; set;}
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
    }
}