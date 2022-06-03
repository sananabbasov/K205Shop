using Business.Abstract;
using Core.Entity.Models;
using Core.Security.TokenHandler;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDTO model)
        {
            return Ok();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            _authManager.Register(model);
            
            return Ok("Okeydi.");
        }

    }
}
