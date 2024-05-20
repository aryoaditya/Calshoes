using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : BaseApiController
    {
        private readonly IGenericRepository<ProductBrand> _brandsRepo;
        private readonly IMapper _imapper;

        public BrandsController(IGenericRepository<ProductBrand> brandsRepo, IMapper imapper)
        {
            _brandsRepo = brandsRepo;
            _imapper = imapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrandReturnDto>>> GetAllBrands()
        {
            var brands = await _brandsRepo.GetAllAsync();

            return Ok(_imapper.Map<IReadOnlyList<ProductBrand>, IReadOnlyList<ProductBrandReturnDto>>(brands));
        }
    }
}