using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<ProductCategory> _categoriesRepo;

        public CategoriesController(IGenericRepository<ProductCategory> categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategory>>> GetAllAsync()
        {
            return Ok(await _categoriesRepo.GetAllAsync());
        }
    }
}