using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IGenericRepository<ProductBrand> _brandRepo;

        public BrandsController(IGenericRepository<ProductBrand> brandRepo)
        {
            _brandRepo = brandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetAllBrands()
        {
            return Ok(await _brandRepo.GetAllAsync());
        }
    }
}