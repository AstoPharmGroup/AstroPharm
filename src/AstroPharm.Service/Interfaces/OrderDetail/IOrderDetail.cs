public interface IOrderDetail
{
    Task<bool> RemoveAsync(long id);
    Task<OrderDetailForResult> GetByIdAsync(long id);
    Task<IEnumerable<OrderDetailForResult>> GetAllAsync();
    Task<OrderDetailForResult> AddAsync(OrderDetailForCreation dto);
    Task<OrderDetailForResult> ModifyAsync(long id, OrderDetailForUpdate dto);
}