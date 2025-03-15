using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs;
using AstroPharm.Service.Interfaces.Order;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Order
{
    public class OrderController : BaseController
    {
        private readonly IOrderInterface _orderService;

        public OrderController(IOrderInterface orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "All Orders",
                Data = await _orderService.GetAllAsync()
            });
        }
        [HttpGet("{userId}/orders")]
        public async Task<IActionResult> GetByUserIdAsync(long userId)
        {
            var res = new Response
            {
                StatusCode = 200,
                Message = "All User's Orders",
                Data = await _orderService.GetByUserIdAsync(userId)
            };
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var orderResponse = new Response
            {
                StatusCode = 200,
                Message = "Order",
                Data = await _orderService.GetByIdAsync(id)
            };
            return Ok(orderResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            await _orderService.RemoveAsync(id);
            return NoContent(); // 204 No Content
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] OrderForCreationDto order)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Order Added",
                Data = await _orderService.AddAsync(order)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderForUpdateDto order, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _orderService.ModifyAsync(id, order)
            });
        }
    }
}
