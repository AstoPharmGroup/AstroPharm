using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.Categories;

public interface ICategoryInterface
{
    Task<bool> DeleteAsync(long id);
    Task<CategoryForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CategoryForResultDto>> GetAllAsync();
    Task<CategoryForResultDto> AddAsync(CategoryForCreationDto dto);
    Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto);
}
