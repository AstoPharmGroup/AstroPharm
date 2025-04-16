using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.Interfaces.Catalogs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AstroPharm.Api.Controllers.Catalogs;

public class CatalogController : BaseController
{
    private readonly ICatalogInterface _CatalogService;

    public CatalogController(ICatalogInterface CatalogService)
    {
        _CatalogService = CatalogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CatalogService.GetAllAsync()
        });
    }

    [HttpGet("get-categories/{catalogName}")]
    public async Task<IActionResult> GetCategoriesByCatalogName([FromRoute] string catalogName)
    {
        var result = await _CatalogService.GetCategoriesByCatalogName(catalogName);

        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Ok",
            Data = result
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CatalogService.GetByIdAsync(id)
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
            Data = await _CatalogService.DeleteAsync(id)
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CatalogForCreationDto Catalog)
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
            Data = await _CatalogService.AddAsync(Catalog)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromBody] CatalogForUpdateDto Catalog, [FromRoute] long id)
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
            Data = await _CatalogService.ModifyAsync(id, Catalog)
        });
    }
}
