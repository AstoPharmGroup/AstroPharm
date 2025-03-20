using AstroPharm.Service.DTOs.Couriers;
using AstroPharm.Service.DTOs.WhishLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.Couriers;

public interface ICourierInterface 
{
    Task<bool> DeleteAsync(long id);
    Task<CourierForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<CourierForResultDto>> GetAllAsync();
    Task<CourierForResultDto> AddAsync(CourierForCreationDto dto);
    Task<CourierForResultDto> ModifyAsync(long id, CourierForUpdateDto dto);
}
