using AstroPharm.Service.DTOs.Deliveries;
using AstroPharm.Service.DTOs.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.Deliveries
{
    public interface IDeliveryInterface
    {
        Task<DeliveryForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<DeliveryForResultDto>> GetAllAsync();
        Task<DeliveryForResultDto> AddAsync(DeliveryForCreationDto dto);
        Task<DeliveryForResultDto> ModifyAsync(long id, DeliveryForUpdateDto dto);
    }
}
