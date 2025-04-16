using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Interfaces.Medications;
using DemoProject.Domain.Configurations.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AstroPharm.Api.Controllers.Medications
{
    public class MedicationController : BaseController
    {
        private readonly IMedicationInterface _medicationService;

        public MedicationController(IMedicationInterface medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.GetAllAsync(@params)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.GetByIdAsync(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
            {

                return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
            }

            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.DeleteAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] MedicationForCreationDto medication)
        {

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
            {

                return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
            }

            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.AddAsync(medication)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] MedicationForUpdateDto medication, [FromRoute] long id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
            {

                return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
            }

            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.ModifyAsync(id, medication)
            });
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<MedicationForResultDto>>> SearchMedications(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest(new { message = "Search term cannot be empty" });
            }

            var result = await _medicationService.SearchAsync(searchTerm);

            return Ok(result);
        }
    }
}
