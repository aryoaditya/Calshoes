using Core.Models;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndCategoriesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndCategoriesSpecification(string sort)
        {
            AddInclude(e => e.ProductBrand);
            AddInclude(e => e.ProductCategory);
            AddOrderBy(e => e.CreatedDate);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.CreatedDate);
                        break;
                }
            }
        }

        public ProductsWithBrandsAndCategoriesSpecification(int id) : base(e => e.Id == id)
        {
            AddInclude(e => e.ProductBrand);
            AddInclude(e => e.ProductCategory);
        }
    }
}