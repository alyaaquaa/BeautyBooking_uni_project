using BeautyBooking.Application.Services;
using BeautyBooking.SharedKernel.Dto;
using Microsoft.AspNetCore.Mvc;
using BeautyBooking.SharedKernel.Parameters;

namespace BeautyBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] ServiceParameters parameters)
        {
            var services = _serviceService.GetServices(parameters);
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto dto)
        {
            var id = await _serviceService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateServiceDto dto)
        {
            await _serviceService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceService.DeleteAsync(id);
            return NoContent();
        }
    }
}
