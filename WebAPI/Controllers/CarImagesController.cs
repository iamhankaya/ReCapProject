using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CarImagesController : ControllerBase
{
    private readonly ICarImageService _carImageService;
    public CarImagesController(ICarImageService carImageService)
    {
        _carImageService = carImageService;
    }

    [HttpGet("getall")]
    public IActionResult Get()
    {
        var result = _carImageService.GetAll();
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _carImageService.GetById(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbycarid")]
    public IActionResult GetByCarId(int id)
    {
        var result = _carImageService.GetByCarId(id);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromForm] IFormFile file, [FromForm] int carId)
    { //file ve carId lazım kullanıcı tarafından.
        CarImage carImage = new() {  };
        var result = _carImageService.Add(carImage,carId,file);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update([FromForm] IFormFile file, [FromForm] int id)
    {
        CarImage oldCarImage = _carImageService.GetById(id).data;
        var result = _carImageService.Update(oldCarImage, file);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete(CarImage carImage)
    {
        var result = _carImageService.Delete(carImage);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}