using BeautyBooking.Application.Services;
using BeautyBooking.SharedKernel.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);

            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto dto)
        {
            var id = await _reservationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateReservationDto dto)
        {
            await _reservationService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reservationService.DeleteAsync(id);
            return NoContent();
        }
    }
}