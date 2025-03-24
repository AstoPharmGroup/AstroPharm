using AstroPharm.Api.Controllers;
using AstroPharm.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

public class OrderDetailController : BaseController
{
    private readonly IOrderDetail orderDetailService;

    public OrderDetailController(IOrderDetail orderDetailService)
    {
        this.orderDetailService = orderDetailService;
    }
    [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "All Orders",
                Data = await orderDetailService.GetAllAsync()
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var orderResponse = new Response
            {
                StatusCode = 200,
                Message = "OrderDetail",
                Data = await orderDetailService.GetByIdAsync(id)
            };
            return Ok(orderResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            await orderDetailService.RemoveAsync(id);
            return NoContent(); // 204 No Content
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] OrderDetailForCreation order)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "Orderdetail Added",
                Data = await orderDetailService.AddAsync(order)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderDetailForUpdate order, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await orderDetailService.ModifyAsync(id, order)
            });
        }
}