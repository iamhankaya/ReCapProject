using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("CustomersGetAll")]
        public IActionResult CustomersGetAll()
        {
            var result = _customerService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CustomersAdd")]
        public IActionResult CustomersAdd(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("CustomersUpdate")]
        public IActionResult CustomersUpdate(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("CustomersDelete")]
        public IActionResult CustomersDelete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCustomerDetails")]

        public IActionResult GetCustomerDetails()
        {
            var result = _customerService.GetCustomerDetail();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
