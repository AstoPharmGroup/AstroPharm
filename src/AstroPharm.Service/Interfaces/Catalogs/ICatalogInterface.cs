using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.DTOs.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.Catalogs;

public interface ICatalogInterface
{
    Task<bool> DeleteAsync(long id);
    Task<CatalogForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CatalogForResultDto>> GetAllAsync();
    Task<CatalogForResultDto> AddAsync(CatalogForCreationDto dto);
    Task<CatalogForResultDto> ModifyAsync(long id, CatalogForUpdateDto dto);
    Task<List<CategoryForResultDto>> GetCategoriesByCatalogName(string catalogName);

}
