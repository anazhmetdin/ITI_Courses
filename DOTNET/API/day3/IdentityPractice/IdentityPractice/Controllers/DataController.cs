﻿using IdentityPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly UserManager<Employee> _userManager;

        public DataController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetUserData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { user.UserName, user.Email, user.HiringDate });
        }
    }
}
