using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.Interfaces.Banners;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AstroPharm.Api.Controllers.Banners
{
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class BannerController : BaseController
    {
        private readonly IBannerInterface _bannerService;

        public BannerController(IBannerInterface bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var banner = await _bannerService.GetAllAsync();
            return Ok(banner);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _bannerService.GetByIdAsync(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _bannerService.DeleteAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] BannerForCreationDto banner)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _bannerService.AddAsync(banner)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] BannerForUpdateDto banner, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _bannerService.ModifyAsync(id, banner)
            });
        }
    }
}
