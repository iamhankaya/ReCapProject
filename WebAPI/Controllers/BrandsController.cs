using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Brands : ControllerBase
    {
        IBrandService _brandService;

        public Brands(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("BrandsGetAll")]
        public IActionResult BrandsGetAll()
        {
            var result = _brandService.GetAll();
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("BrandsAdd")]
        public IActionResult BrandsAdd(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("BrandsUpdate")]
        public IActionResult BrandsUpdate(Brand brand)
        {
            var result = _brandService.Update(brand);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("BrandsDelete")]
        public IActionResult BrandsDelete(Brand brand)
        {
            var result = _brandService.Delete(brand);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
