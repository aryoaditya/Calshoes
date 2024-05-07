using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _imapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IMapper imapper)
        {
            _productsRepo = productsRepo;
            _imapper = imapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductReturnDto>>> GetAllProducts()
        {
            var spec = new ProductsWithBrandsAndCategoriesSpecification();
            var products = await _productsRepo.GetAllWithSpecAsync(spec);

            return Ok(_imapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDto>> GetProductById(int id)
        {
            var spec = new ProductsWithBrandsAndCategoriesSpecification(id);
            var product = await _productsRepo.GetByIdWithSpecAsync(spec);

            return _imapper.Map<Product, ProductReturnDto>(product);
        }
    }
}