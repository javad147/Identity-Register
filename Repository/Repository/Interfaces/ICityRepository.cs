using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Repository.Interfaces
{
    public interface ICityRepository
    {
        Task CreateAsync(City city);
        Task DeleteAsync(City city);
        Task<City> GetByIdAsync(int id);
        Task UpdateAsync(City city);
        IQueryable<City> FindAllWithIncludes(params Expression<Func<City, object>>[] includes);
        IQueryable<City> FindBy(Expression<Func<City, bool>> predicate, params Expression<Func<City, object>>[] includes);

    }
}
