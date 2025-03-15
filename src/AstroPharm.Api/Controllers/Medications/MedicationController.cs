using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.Interfaces.Medications;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Medications
{
<<<<<<< HEAD

=======
>>>>>>> 74b95a1ef7b0530fd50629725f818910c07d5482
    public class MedicationController : BaseController
    {
        private readonly IMedicationInterface _medicationService;

        public MedicationController(IMedicationInterface medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.GetAllAsync()
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
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _medicationService.ModifyAsync(id, medication)
            });
        }
    }
}
