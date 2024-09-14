using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        IPaymentDetailService _paymentDetailService;

        public PaymentDetailsController(IPaymentDetailService paymentDetailService)
        {
            _paymentDetailService = paymentDetailService;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _paymentDetailService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]

        public IActionResult Add(PaymentDetail paymentDetail)
        {
            var result = _paymentDetailService.Add(paymentDetail);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]

        public IActionResult Update(PaymentDetail paymentDetail)
        {
            var result = _paymentDetailService.Update(paymentDetail);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]

        public IActionResult Delete(PaymentDetail paymentDetail)
        {
            var result = _paymentDetailService.Delete(paymentDetail);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreatePaymentDetail")]

        public IActionResult CreatePayment(int carId, int paymentAmount, int cardId, string description)
        {
            var result = _paymentDetailService.CreatePayment(carId,paymentAmount,cardId,description);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
