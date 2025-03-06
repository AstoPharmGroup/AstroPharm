namespace AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.DTOs.Medications;
public interface IOrderInterface
{
    Task<bool> RemoveAsync(long id);
    Task<OrderForResultDto> GetByIdAsync(long id);
    Task<List<OrderForResultDto>> GetAllAsync();
    Task<List<OrderForResultDto>> GetByUserIdAsync(long userId);
    Task<OrderForResultDto> AddAsync(OrderForCreationDto dto);
    Task<OrderForResultDto> ModifyAsync(long id,OrderForUpdateDto dto);
}