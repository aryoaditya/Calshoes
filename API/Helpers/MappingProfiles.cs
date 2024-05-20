using API.Dtos;
using AutoMapper;
using Core.Models;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductCategory, o => o.MapFrom(s => s.ProductCategory.Name));

            CreateMap<ProductBrand, ProductBrandReturnDto>();

            CreateMap<ProductCategory, ProductCategoryReturnDto>();
        }
    }
}