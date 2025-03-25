using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.WhishLists;
using AstroPharm.Service.Interfaces.Wishlists;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.WhichLists
{
    public class WishListController : BaseController
    {
        private readonly IWishlistInterface _wishListService;

        public WishListController(IWishlistInterface WishListService)
        {
            _wishListService = WishListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _wishListService.GetAllAsync()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _wishListService.GetByIdAsync(id)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _wishListService.DeleteAsync(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] WishListForCreationDto WishList)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _wishListService.AddAsync(WishList)
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] WishListForUpdateDto WishList, [FromRoute] long id)
        {
            return Ok(new Response
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _wishListService.ModifyAsync(id, WishList)
            });
        }
    }
}