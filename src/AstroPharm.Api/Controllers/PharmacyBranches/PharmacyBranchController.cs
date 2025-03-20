using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.PharmacyBranchs;
using AstroPharm.Service.Interfaces.PharmacyBranchs;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.PharmacyBranches
{
    public class PharmacyBranchController : BaseController
    {
        private readonly IPharmacyBranchInterface _pharmacyBranchService;

        public PharmacyBranchController(IPharmacyBranchInterface pharmacyBranchService)
        {
            _pharmacyBranchService = pharmacyBranchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyBranchService.GetAllAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyBranchService.GetByIdAsync(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyBranchService.RemoveAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PharmacyBranchForCreationDto pharmacyBranch)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyBranchService.AddAsync(pharmacyBranch)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] PharmacyBranchForUpdateDto pharmacyBranch, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyBranchService.ModifyAsync(id, pharmacyBranch)
            });
        }
    }
}
