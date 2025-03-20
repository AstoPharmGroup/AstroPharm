using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Couriers;
using AstroPharm.Service.DTOs.WhishLists;
using AstroPharm.Service.Interfaces.Couriers;
using AstroPharm.Service.Services.Couriers;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Couriers
{
    public class CourierController : BaseController
    {
        private readonly ICourierInterface courierInterface;

        public CourierController(ICourierInterface courierInterface)
        {
            this.courierInterface = courierInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await courierInterface.GetAllAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await courierInterface.GetByIdAsync(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await courierInterface.DeleteAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CourierForCreationDto Courier)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await courierInterface.AddAsync(Courier)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] CourierForUpdateDto Courier, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await courierInterface.ModifyAsync(id, Courier)
            });
        }
    }
}
