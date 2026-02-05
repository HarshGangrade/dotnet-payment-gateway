////using Microsoft.AspNetCore.Http;
////using Microsoft.AspNetCore.Mvc;

////namespace PaymentGatewayProject.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class PaymentsController : ControllerBase
////    {
////    }
////}
//using Microsoft.AspNetCore.Mvc;

//namespace PaymentGatewayProject.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PaymentsController : ControllerBase
//    {
//        [HttpPost("process")]
//        public IActionResult ProcessPayment([FromBody] PaymentRequest request)
//        {
//            if (request == null || request.Amount <= 0)
//            {
//                return BadRequest(new
//                {
//                    message = "Invalid payment amount"
//                });
//            }

//            decimal finalAmount = request.Amount;
//            bool feeApplied = false;

//            if (request.Amount > 1000)
//            {
//                finalAmount = request.Amount + (request.Amount * 0.02m);
//                feeApplied = true;
//            }

//            return Ok(new
//            {
//                originalAmount = request.Amount,
//                finalAmount = finalAmount,
//                feeApplied = feeApplied,
//                status = "SUCCESS"
//            });
//        }
//    }

//    public class PaymentRequest
//    {
//        public decimal Amount { get; set; }
//    }
//}

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
