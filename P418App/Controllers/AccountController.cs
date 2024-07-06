﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Accounts; 
using Service.Services.Interfaces; 
using System.Threading.Tasks;

namespace P418App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
            await _accountService.CreateRolesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _accountService.SignUpAsync(request);
            if (!response.Success) return BadRequest(Response);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() 
        {
            return Ok(await _accountService.GetUsersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromBody] UserRoleDto request) 
        {
            var response = await _accountService.AddRoleToUserAsync(request);
            if ( !response.Success)
            {
                return BadRequest(Response);
                
            }
            return Ok(response);
        }

        [HttpGet]

        public async Task<IActionResult> GetRolesAsync() 
        {
            return Ok(await _accountService.GetRolesAsync());
        }
    }
}
