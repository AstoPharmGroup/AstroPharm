using AstroPharm.Service.DTOs.PharmacyBranchs;
using AstroPharm.Service.DTOs.PharmacyStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.PharmacyStocks
{
    public interface IPharmacyStockInterface
    {
        Task<bool> RemoveAsync(long id);
        Task<PharmacyStockForResult> GetByIdAsync(long id);
        Task<List<PharmacyStockForResult>> GetAllAsync();
        Task<PharmacyStockForResult> AddAsync(PharmacyStockForCreationDto dto);
        Task<PharmacyStockForResult> ModifyAsync(long id, PharmacyStockForUpdateDto dto);
    }
}
