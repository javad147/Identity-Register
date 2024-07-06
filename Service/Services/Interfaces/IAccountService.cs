using Service.DTOs.Accounts;
using Service.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
        Task CreateRolesAsync();
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserRoleResponse> AddRoleToUserAsync(UserRoleDto user);
        Task<IEnumerable<RoleDto>>GetRolesAsync();
    }
}
