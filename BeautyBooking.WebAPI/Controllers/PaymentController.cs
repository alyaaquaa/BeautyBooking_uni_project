using BeautyBooking.Application.Services;
using BeautyBooking.SharedKernel.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            var id = await _paymentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePaymentDto dto)
        {
            await _paymentService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.DeleteAsync(id);
            return NoContent();
        }
    }
}