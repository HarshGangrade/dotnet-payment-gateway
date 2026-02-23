using PaymentGatewayProject.Service;
using PaymentGatewayProject.Models;
using Xunit;

namespace PaymentGatewayProject.Tests
{
    public class PaymentServiceTests
    {
        private readonly PaymentService _service;

        public PaymentServiceTests()
        {
            _service = new PaymentService();
        }

        [Fact]
        public void Amount_Less_Than_Or_Equal_1000_Should_Not_Apply_Fee()
        {
            var result = _service.Process(500);

            Assert.False(result.FeeApplied);
            Assert.Equal(500, result.FinalAmount);
        }

        [Fact]
        public void Amount_Greater_Than_1000_Should_Apply_2_Percent_Fee()
        {
            var result = _service.Process(3000);

            Assert.True(result.FeeApplied);
            Assert.Equal(3060, result.FinalAmount);
        }

        [Fact]
        public void Amount_1001_Should_Apply_2Percent_Fee()
        {
          
            var service = new PaymentService();

            var result = service.Process(1001);
            Assert.True(result.FeeApplied);
            Assert.Equal(1021.02m, result.FinalAmount);
        }

        [Fact]
        public void Amount_Equal_1000_Should_Not_Apply_Fee()
        {
            var result = _service.Process(1000);

            Assert.False(result.FeeApplied);
            Assert.Equal(1000, result.FinalAmount);
        }

        [Fact]
        public void Invalid_Amount_Should_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => _service.Process(0));
        }
    }
}
