using Service.DTOs.Cities;
using Service.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto>GetByIdAsync(int id);
        Task CreateAsync(CityCreateDto model);
        Task DeleteAsync(int id);
        Task EditAsync(int id, CountryEditDto model);
        Task EditAsync(int id, CityEditDto cityEditDto);
    }
}
