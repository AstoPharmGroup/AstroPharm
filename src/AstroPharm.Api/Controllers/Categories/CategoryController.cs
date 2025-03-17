using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Categories;

public class CategoryController : BaseController
{
    private readonly ICategoryInterface _CategoryService;

    public CategoryController(ICategoryInterface CategoryService)
    {
        _CategoryService = CategoryService;
    }

    [HttpGet]

    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.GetAllAsync()
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
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CategoryService.ModifyAsync(id, Category)
        });
    }
}
