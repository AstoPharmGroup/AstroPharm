using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.DTOs.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.Banners;

public interface IBannerInterface
{
    Task<bool> DeleteAsync(long id);
    Task<BannerForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<BannerForResultDto>> GetAllAsync();
    Task<BannerForResultDto> AddAsync(BannerForCreationDto dto);
    Task<BannerForResultDto> ModifyAsync(long id, BannerForUpdateDto dto);
}
