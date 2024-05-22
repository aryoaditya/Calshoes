using API.Dtos;
using API.Errors;
using API.Helpers;
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
        public async Task<ActionResult<List<ProductReturnDto>>> GetAllProducts([FromQuery] ProductSpecParameters productParams)
        {
            var spec = new ProductsWithBrandsAndCategoriesSpecification(productParams);

            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await _productsRepo.CountAsync(countSpec);

            var products = await _productsRepo.GetAllWithSpecAsync(spec);

            var data = _imapper.Map<IReadOnlyList<ProductReturnDto>>(products);

            return Ok(new Pagination<ProductReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
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