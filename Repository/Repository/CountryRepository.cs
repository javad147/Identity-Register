using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Country> GetCountryByNameWithCities(string name)
        {
            return await _dbSet.Include(m => m.Cities)
                               .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task UpdateAsync(Country country)
        {
            _dbSet.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAllWithCitiesAsync()
        {
            return await _dbSet.Include(c => c.Cities).ToListAsync();
        }

        Task ICountryRepository.CreateAsync(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
