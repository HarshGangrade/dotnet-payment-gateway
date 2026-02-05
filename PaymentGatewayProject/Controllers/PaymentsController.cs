using Microsoft.AspNetCore.Mvc;
using PaymentGatewayProject.Models;
using PaymentGatewayProject.Service;

namespace PaymentGatewayProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] PaymentRequest request)
        {
           
            if (request == null)
                return BadRequest("Invalid request");

            try
            {
                var result = _paymentService.Process(request.Amount);

                return Ok(new
                {
                    originalAmount = result.OriginalAmount,
                    finalAmount = result.FinalAmount,
                    feeApplied = result.FeeApplied,
                    status = "SUCCESS"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
