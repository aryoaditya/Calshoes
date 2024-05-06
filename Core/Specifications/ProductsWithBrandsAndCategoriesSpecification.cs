using Core.Models;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndCategoriesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndCategoriesSpecification()
        {
            AddInclude(e => e.ProductBrand);
            AddInclude(e => e.ProductCategory);
        }

        public ProductsWithBrandsAndCategoriesSpecification(int id) : base(e => e.Id == id)
        {
            AddInclude(e => e.ProductBrand);
            AddInclude(e => e.ProductCategory);
        }
    }
}