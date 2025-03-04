namespace AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.DTOs.Medications;
public interface IOrderInterface
{
    Task<bool> RemoveAsync(long id);
    Task<OrderForResultDto> AddAsync(OrderForCreationDto dto);
    Task<OrderForResultDto> GetByIdAsync(long id);
    Task<IEnumerable<OrderForResultDto>> GetAllAsync();
    Task<OrderForResultDto> ModifyAsync(long id,OrderForUpdateDto dto);
}