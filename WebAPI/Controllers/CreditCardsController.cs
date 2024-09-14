using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("CreditCardGetAll")]

        public IActionResult GetAll()
        {
            var result = _creditCardService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreditCardAdd")]

        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreditCardUpdate")]

        public IActionResult Update(CreditCard creditCard)
        {
            var result = _creditCardService.Update(creditCard);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("CreditCardDelete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardService.Delete(creditCard);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _creditCardService.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("UpdateCardLimit")]

        public IActionResult UpdateCardLimit(int cardNo, int paymentAmount)
        {
            var result = _creditCardService.UpdateCardLimit(cardNo, paymentAmount);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
