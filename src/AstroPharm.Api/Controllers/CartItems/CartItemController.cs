using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.CartItems;
using AstroPharm.Service.Interfaces.CartItems;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.CartItems
{
    public class CartItemController : BaseController
    {
        private readonly ICartItemInterface _cartItemService;

        public CartItemController(ICartItemInterface cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _cartItemService.GetCartItem(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _cartItemService.DeleteAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CartItemForCreationDto cartItem)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _cartItemService.AddAsync(cartItem)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] CartItemForUpdateDto cartItem, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _cartItemService.UpdateAsync(id, cartItem)
            });
        }
    }
}
