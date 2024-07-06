using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.DTOs.Countries;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P418App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            await _countryService.CreateAsync(request);
            return Ok();
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();
            await _countryService.DeleteAsync((int)id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _countryService.UpdateAsync(id, request);
            return Ok();
        }
    }
}
