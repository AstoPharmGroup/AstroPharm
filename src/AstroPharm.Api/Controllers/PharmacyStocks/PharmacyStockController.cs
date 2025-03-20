using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.PharmacyStocks;
using AstroPharm.Service.Interfaces.PharmacyStocks;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.PharmacyStocks
{
    public class PharmacyStockController : BaseController
    {
        private readonly IPharmacyStockInterface _pharmacyStockService;

        public PharmacyStockController(IPharmacyStockInterface pharmacyStockService)
        {
            _pharmacyStockService = pharmacyStockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyStockService.GetAllAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyStockService.GetByIdAsync(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyStockService.RemoveAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PharmacyStockForCreationDto pharmacyStock)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyStockService.AddAsync(pharmacyStock)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] PharmacyStockForUpdateDto pharmacyStock, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _pharmacyStockService.ModifyAsync(id, pharmacyStock)
            });
        }
    }
}
