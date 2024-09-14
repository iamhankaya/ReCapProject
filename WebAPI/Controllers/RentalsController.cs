using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("RentalsGetAll")]
        public IActionResult RentalsGetAll()
        {
            var result = _rentalService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("RentCar")]
        public IActionResult RentCar(int customerId,int carId)
        {
            var result = _rentalService.RentCar(customerId,carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("ReturnCar")]
        public IActionResult ReturnCar(int carId)
        {
            var result = _rentalService.ReturnCar(carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarRentalDetails")]
        public IActionResult GetCarRentalDetails(int carId)
        {
            var result = _rentalService.GetCarRentalDetails(carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCustomerRentalDetails")]
        public IActionResult GetCustomerRentalDetails(int customerId)
        {
            var result = _rentalService.GetCustomerRentalDetails(customerId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetRentalDetails")]

        public IActionResult GetRentalDetails()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

    }
}

