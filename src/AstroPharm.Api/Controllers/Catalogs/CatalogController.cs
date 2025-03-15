using AstroPharm.Api.Helpers;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.Interfaces.Catalogs;
using Microsoft.AspNetCore.Mvc;

namespace AstroPharm.Api.Controllers.Catalogs;

<<<<<<< HEAD

=======
>>>>>>> 74b95a1ef7b0530fd50629725f818910c07d5482
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
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _CatalogService.ModifyAsync(id, Catalog)
        });
    }
}
