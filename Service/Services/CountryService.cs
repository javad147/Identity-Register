using AutoMapper;
using Domain.Entities;
using Repository.Repository.Interfaces;
using Service.DTOs.Countries;
using Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepo, IMapper mapper)
        {
            _countryRepository = countryRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryCreateDto model)
        {
            await _countryRepository.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            if (country != null)
            {
                await _countryRepository.DeleteAsync(country);
            }
        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            if (country != null)
            {
                country.Name = model.Name;
                await _countryRepository.UpdateAsync(country);
            }
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }

        public async Task<IEnumerable<CountryByCitiesDto>> GetAllWithCitiesAsync()
        {
            var countries = await _countryRepository.GetAllWithCitiesAsync();
            return _mapper.Map<IEnumerable<CountryByCitiesDto>>(countries);
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryByCitiesDto> GetCountryByNameWithCities(string name)
        {
            var country = await _countryRepository.GetCountryByNameWithCities(name);
            return _mapper.Map<CountryByCitiesDto>(country);
        }

        public async Task UpdateAsync(int id, CountryEditDto request)
        {
            var country = await _countryRepository.GetByIdAsync(id);
            if (country != null)
            {
                country.Name = request.Name;
                await _countryRepository.UpdateAsync(country);
            }
        }
    }
}
