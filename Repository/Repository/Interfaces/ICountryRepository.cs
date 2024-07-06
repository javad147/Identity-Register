using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Repository.Interfaces
{
    public interface ICountryRepository
    {
        Task CreateAsync(Country entity);
        Task DeleteAsync(Country country);
        Task<IEnumerable<Country>> GetAllAsync();
        Task<IEnumerable<Country>> GetAllWithCitiesAsync();  
        Task<Country> GetByIdAsync(int id);
        Task UpdateAsync(Country country);
        Task<Country> GetCountryByNameWithCities(string name);
    }
}
