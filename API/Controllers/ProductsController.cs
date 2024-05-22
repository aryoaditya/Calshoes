using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _imapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IMapper imapper)
        {
            _productsRepo = productsRepo;
            _imapper = imapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductReturnDto>>> GetAllProducts(string sort,  int? brandId, int? categoryId)
        {
            var spec = new ProductsWithBrandsAndCategoriesSpecification(sort, brandId, categoryId);
            var products = await _productsRepo.GetAllWithSpecAsync(spec);

            return Ok(_imapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductReturnDto>> GetProductById(int id)
        {
            var spec = new ProductsWithBrandsAndCategoriesSpecification(id);
            var product = await _productsRepo.GetByIdWithSpecAsync(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _imapper.Map<Product, ProductReturnDto>(product);
        }
    }
}