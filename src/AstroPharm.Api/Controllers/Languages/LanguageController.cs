using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Languages;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AstroPharm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageInterface _languageService;

        public LanguageController(ILanguageInterface languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            return Ok(await _languageService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(long id)
        {
            var language = await _languageService.GetByIdAsync(id);
            return language is not null ? Ok(language) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Language>> CreateLanguage([FromBody] LanguageForCreationDto dto)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
            {

                return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
            }

            var createdLanguage = await _languageService.AddAsync(dto);
            return CreatedAtAction(nameof(GetLanguage), new { id = createdLanguage.Id }, createdLanguage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(long id, [FromBody] LanguageForUpdateDto dto)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
            {

                return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
            }

            var updatedLanguage = await _languageService.ModifyAsync(id, dto);
            return Ok(updatedLanguage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(long id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
            {

                return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
            }

            var result = await _languageService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
