using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Wishlists;
using AstroPharm.Service.Interfaces.Wishlists;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.WishList;

public class WishListController : BaseController
{
    private readonly IWishlistService _wishListService;

    public WishListController(IWishlistService wishListService)
    {
        _wishListService = wishListService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _wishListService.RetrieveAllAsync()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _wishListService.RetrieveByIdAsync(id)
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _wishListService.RemoveAsync(id)
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] WishlistForCreationDto wishlist)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _wishListService.AddAsync(wishlist)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] WishlistForUpdateDto wishlist, [FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _wishListService.ModifyAsync(id, wishlist)
        });
    }
}