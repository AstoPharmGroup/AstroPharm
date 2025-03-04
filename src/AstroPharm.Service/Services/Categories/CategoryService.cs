using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Categories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Categories;

public class CategoryService : ICategoryInterface
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IRepository<Category> CategoryRepository, IMapper mapper)
    {
        _categoryRepository = CategoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryForResultDto> AddAsync(CategoryForCreationDto dto)
    {
        var Category = await _categoryRepository.SelectAll()
            .Where(x => x.CategoryName == dto.CategoryName)
            .FirstOrDefaultAsync();

        if (Category != null)
            throw new AstroPharmException(409, "This Category already exists");

        var mapped = _mapper.Map<Category>(dto);
        await _categoryRepository.InsertAsync(mapped);

        return _mapper.Map<CategoryForResultDto>(mapped);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var Category = await _categoryRepository.SelectAll().FirstOrDefaultAsync(x => x.Id == id);
        if (Category == null)
            throw new AstroPharmException(404, "Category not found!");

        await _categoryRepository.DeleteAsync(id);
        return true;

    }

    public async Task<IEnumerable<CategoryForResultDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.SelectAll()
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<CategoryForResultDto>>(categories);
    }

    public async Task<CategoryForResultDto> GetByIdAsync(long id)
    {
        var Category = await _categoryRepository.SelectByIdAsync(id);
        if (Category == null)
            throw new AstroPharmException(404, "Category not found!");

        return _mapper.Map<CategoryForResultDto>(Category);
    }

    public async Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto)
    {
        var Category = await _categoryRepository.SelectByIdAsync(id);
        if (Category == null)
            throw new AstroPharmException(409, "Category not found!");

        var mapped = _mapper.Map(dto, Category);
        await _categoryRepository.UpdateAsync(mapped);

        return _mapper.Map<CategoryForResultDto>(mapped);
    }
}
