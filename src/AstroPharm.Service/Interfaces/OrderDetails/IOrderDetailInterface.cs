using AstroPharm.Service.DTOs.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.OrderDetails
{
    public interface IOrderDetailInterface
    {
        Task<bool> RemoveAsync(long id);
            Task<OrderDetailForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<OrderDetailForResultDto>> GetAllAsync();
        Task<OrderDetailForResultDto> AddAsync(OrderDetailForCreationDto dto);
        Task<OrderDetailForResultDto> ModifyAsync(long id, OrderDetailForUpdateDto dto);
    }
}
