using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repository.Interfaces;
using Service.DTOs.Cities;
using Service.DTOs.Countries;
using Service.Exceptions;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepo;
        private readonly ILogger<CityService> _logger;

        public CityService(ICityRepository cityRepo, IMapper mapper, ICountryRepository countryRepo, ILogger<CityService> logger)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
            _countryRepo = countryRepo;
            _logger = logger;
        }

        public async Task CreateAsync(CityCreateDto model)
        {
            _logger.LogInformation($"Attempting to create city with CountryId: {model.CountryId}");

            var existCountry = await _countryRepo.GetByIdAsync(model.CountryId);
            if (existCountry == null)
            {
                _logger.LogWarning($"Country with ID {model.CountryId} not found.");
                throw new NotFoundException($"{model.CountryId} - Country not found");
            }

            var data = _mapper.Map<City>(model);
            await _cityRepo.CreateAsync(data);

            _logger.LogInformation($"City {data.Name} created successfully.");
        }


        public async Task DeleteAsync(int id)
        {
            var city = await _cityRepo.GetByIdAsync(id);
            if (city != null)
            {
                await _cityRepo.DeleteAsync(city);
            }
        }

        public async Task EditAsync(int id, CityEditDto model)
        {
            var city = await _cityRepo.GetByIdAsync(id);
            if (city != null)
            {
                city = _mapper.Map(model, city);
                await _cityRepo.UpdateAsync(city);
            }
            else
            {
                throw new NotFoundException($"City with id {id} not found.");
            }
        }

        public Task EditAsync(int id, CountryEditDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var cities = await _cityRepo.FindAllWithIncludes(m => m.Country).ToListAsync();
            return _mapper.Map<IEnumerable<CityDto>>(cities);
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            var city = await _cityRepo.FindBy(m => m.Id == id, m => m.Country).FirstOrDefaultAsync();
            if (city == null)
            {
                throw new NotFoundException($"City with id {id} not found.");
            }
            return _mapper.Map<CityDto>(city);
        }

     
    }
}
