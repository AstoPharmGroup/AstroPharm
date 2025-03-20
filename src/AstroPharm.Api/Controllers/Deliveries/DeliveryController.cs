using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Deliveries;
using AstroPharm.Service.Interfaces.Deliveries;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Deliveries
{
    public class DeliveryController : BaseController
    {
        private readonly IDeliveryInterface _deliveryService;

        public DeliveryController(IDeliveryInterface deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _deliveryService.GetAllAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _deliveryService.GetByIdAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DeliveryForCreationDto delivery)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _deliveryService.AddAsync(delivery)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] DeliveryForUpdateDto delivery, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _deliveryService.ModifyAsync(id, delivery)
            });
        }
    }
}
