using AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Mappers;
using AutoMapper;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;

public class OrderService : IOrderInterface
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Order> _orderRepository;


    public OrderService(
        IMapper mapper,
        IRepository<User> userRepository,
        IRepository<Order> orderRepository
        )
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _orderRepository = orderRepository;

    }

    public async Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
      
            var order = _mapper.Map<Order>(dto);

            order.CreatedAt = DateTime.UtcNow;

            return _mapper.Map<OrderForResultDto>(await _orderRepository.InsertAsync(order));
        
    }

    public async Task<List<OrderForResultDto>> GetAllAsync()
    {
        var orders = _orderRepository.SelectAll();
        
        return _mapper.Map<List<OrderForResultDto>>(orders);
    }

    public async Task<OrderForResultDto> GetByIdAsync(long id)
    {
        var order = await _orderRepository.SelectByIdAsync(id)
            ?? throw new AstroPharmException(404, "Order is not found");

        return _mapper.Map<OrderForResultDto>(order);
    }

public async Task<List<OrderForResultDto>> GetByUserIdAsync(long userId)
{
    var userOrders = _orderRepository.SelectAll().Where(x => x.UserId == userId).ToList();

    if (!userOrders.Any())
        throw new AstroPharmException(404, "Orders not found for this user");

    return _mapper.Map<List<OrderForResultDto>>(userOrders);
}


    public async Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto)
{
    var existingOrder = await _orderRepository.SelectByIdAsync(id)
        ?? throw new AstroPharmException(404, "Order not found");

    _mapper.Map(dto, existingOrder);
    existingOrder.UpdatedAt = DateTime.UtcNow;

    return _mapper.Map<OrderForResultDto>(await _orderRepository.UpdateAsync(existingOrder));
}


    public async Task<bool> RemoveAsync(long id)
    {
        var order = await _orderRepository.SelectByIdAsync(id);
        if (order is not null)
        {

            return await _orderRepository.DeleteAsync(id);
        }

        throw new AstroPharmException(404, "Order not found");

    }
}