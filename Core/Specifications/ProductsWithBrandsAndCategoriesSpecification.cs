using Core.Models;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndCategoriesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndCategoriesSpecification(ProductSpecParameters productParams) : base(x => 
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.CategoryId.HasValue || x.ProductCategoryId == productParams.CategoryId)
        )
        {
            AddInclude(e => e.ProductBrand);
            AddInclude(e => e.ProductCategory);
            AddOrderBy(e => e.CreatedDate);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
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