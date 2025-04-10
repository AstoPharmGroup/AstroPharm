using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.SubCategories;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Catalogs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Catalogs;

public class CatalogService : ICatalogInterface
{
    private readonly IRepository<Catalog> _catalogRepository;
    private readonly IMapper _mapper;

    public CatalogService(IRepository<Catalog> catalogRepository, IMapper mapper)
    {
        _catalogRepository = catalogRepository;
        _mapper = mapper;
    }

    public async Task<CatalogForResultDto> AddAsync(CatalogForCreationDto dto)
    {
        var catalog = await _catalogRepository.SelectAll()
            .Where(x => x.CatalogName == dto.CatalogName)
            .FirstOrDefaultAsync();

        if (catalog != null)
            throw new AstroPharmException(409, "This Catalog already exists");

        var mapped = _mapper.Map<Catalog>(dto);
        await _catalogRepository.InsertAsync(mapped);

        return _mapper.Map<CatalogForResultDto>(mapped);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var catalog = await _catalogRepository.SelectAll().FirstOrDefaultAsync(x => x.Id == id);
        if (catalog == null)
            throw new AstroPharmException(404, "Catalog not found!");

        await _catalogRepository.DeleteAsync(id);
        return true;

    }

    public async Task<IEnumerable<CatalogForResultDto>> GetAllAsync()
    {
        var catalogs = await _catalogRepository.SelectAll()
            //.AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<CatalogForResultDto>>(catalogs);
    }

    public async Task<CatalogForResultDto> GetByIdAsync(long id)
    {
        var catalog = await _catalogRepository.SelectByIdAsync(id);
        if (catalog == null)
            throw new AstroPharmException(404, "Catalog not found!");

        return _mapper.Map<CatalogForResultDto>(catalog);
    }

    public async Task<List<CategoryForResultDto>> GetCategoriesByCatalogName(string catalogName)
    {
        var catalog = await _catalogRepository.SelectAll()
            .Include(c => c.Categories)
            .FirstOrDefaultAsync(c => c.CatalogName == catalogName);

        if (catalog == null)
            throw new AstroPharmException(404, "Catalog not found!");

        var categoryDtos = catalog.Categories.Select(c => new CategoryForResultDto
        {
            Id = c.Id,
            CategoryName = c.CategoryName,
            CatalogId = c.CatalogId,
            Description = c.Description,
            
            
        }).ToList();

        return categoryDtos;
    }


    public async Task<CatalogForResultDto> ModifyAsync(long id, CatalogForUpdateDto dto)
    {
        var catalog = await _catalogRepository.SelectByIdAsync(id);
        if (catalog == null)
            throw new AstroPharmException(409, "Catalog not found!");

        var mapped = _mapper.Map(dto, catalog);
        await _catalogRepository.UpdateAsync(mapped);

        return _mapper.Map<CatalogForResultDto>(mapped);
    }
}
