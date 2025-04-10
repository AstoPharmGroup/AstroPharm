using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.Interfaces.Categories;
using DemoProject.Domain.Configurations.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AstroPharm.Api.Controllers.Categories;

public class CategoryController : BaseController
{
    private readonly ICategoryInterface _CategoryService;

    public CategoryController(ICategoryInterface CategoryService)
    {
        _CategoryService = CategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.GetAllAsync(@params)
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.GetByIdAsync(id)
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.DeleteAsync(id)
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CategoryForCreationDto Category)
    {
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.AddAsync(Category)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] CategoryForUpdateDto Category, [FromRoute] long id)
    {
        var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

        if (userRole == null || (userRole != "Admin" && userRole != "SuperAdmin"))
        {

            return Unauthorized(new { message = $"{userRole} ,You are not allowed to use this method!" });
        }

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.ModifyAsync(id, Category)
        });
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync(string searchTerm)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.SearchAsync(searchTerm)
        });

    }
}
