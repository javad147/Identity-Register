using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Cities;
using Service.Exceptions;
using Service.Services.Interfaces;
using System.Threading.Tasks;

namespace P418App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _cityService.CreateAsync(request);
                return CreatedAtAction(nameof(GetByID), new { id = request.CountryId }, new { response = "Successfully" });
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, $"Country with ID {request.CountryId} not found.");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the city.");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound(new { message = $"City with ID {id} not found." });
            }
            return Ok(city);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest(new { message = "ID cannot be null." });

            var city = await _cityService.GetByIdAsync((int)id);
            if (city == null)
            {
                return NotFound(new { message = $"City with ID {id} not found." });
            }

            await _cityService.DeleteAsync((int)id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CityEditDto cityEditDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = await _cityService.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound(new { message = $"City with ID {id} not found." });
            }

            await _cityService.EditAsync(id, cityEditDto);
            return NoContent();
        }
    }
}
