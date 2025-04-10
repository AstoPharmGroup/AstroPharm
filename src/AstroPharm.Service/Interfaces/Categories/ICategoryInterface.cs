using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.DTOs.Medications;
using DemoProject.Domain.Configurations.Pagination;
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
    Task<CategoryForResultDto> AddAsync(CategoryForCreationDto dto);
    Task<List<MedicationForResultDto>> SearchAsync(string searchTerm);
    Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto);
    Task<IEnumerable<CategoryForResultDto>> GetAllAsync(PaginationParams @params);
}
