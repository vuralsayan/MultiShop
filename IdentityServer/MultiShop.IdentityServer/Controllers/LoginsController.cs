﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    //[Authorize(LocalApi.PolicyName)]
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {

            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            if (result.Succeeded)
            {
                GetCheckAppUserVİewModel model = new GetCheckAppUserVİewModel();
                model.Username = userLoginDto.Username;
                model.ID = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return Ok("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }
}

