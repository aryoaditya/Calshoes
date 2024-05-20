using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : BaseApiController
    {
        private readonly IGenericRepository<ProductCategory> _categoriesRepo;
        private readonly IMapper _imapper;

        public CategoriesController(IGenericRepository<ProductCategory> categoriesRepo, IMapper imapper)
        {
            _categoriesRepo = categoriesRepo;
            _imapper = imapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryReturnDto>>> GetAllCategories()
        {
            var categories = await _categoriesRepo.GetAllAsync();

            return Ok(_imapper.Map<IReadOnlyList<ProductCategory>, IReadOnlyList<ProductCategoryReturnDto>>(categories));
        }
    }
}