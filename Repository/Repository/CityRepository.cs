using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repository.Interfaces;
using System;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public IQueryable<City> FindAllWithIncludes(params Expression<Func<City, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<City> FindBy(Expression<Func<City, bool>> predicate, params Expression<Func<City, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public async Task CreateAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        Task ICityRepository.UpdateAsync(City city)
        {
            throw new NotImplementedException();
        }
    }
}
