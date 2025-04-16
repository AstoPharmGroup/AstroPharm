using AstroPharm.Api.Controllers;
using AstroPharm.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class AuthController : BaseController
{
    private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AuthentificateAsync(LoginDto dto)
        {
                var result = await service.AuthenticateAsync(dto);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
                    
                var userId = User.FindFirst("Id")?.Value;
                await service.LogoutAsync(Convert.ToInt64(userId));
            return Ok();
        }

}
