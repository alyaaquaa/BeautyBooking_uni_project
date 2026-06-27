using BeautyBooking.Application.Services;
using BeautyBooking.SharedKernel.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeautyBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientDto dto)
        {
            var id = await _clientService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClientDto dto)
        {
            await _clientService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
