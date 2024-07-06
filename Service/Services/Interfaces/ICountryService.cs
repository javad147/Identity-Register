using System.Collections.Generic;
using System.Threading.Tasks;
using Service.DTOs.Countries;
using AutoMapper;
using Service;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto> GetByIdAsync(int id);
        Task CreateAsync(CountryCreateDto model);
        Task<IEnumerable<CountryByCitiesDto>> GetAllWithCitiesAsync();
        Task DeleteAsync(int id);
        Task EditAsync(int id, CountryEditDto model);
        Task<CountryByCitiesDto> GetCountryByNameWithCities(string name);
        Task UpdateAsync(int id, CountryEditDto request);
    }
}
