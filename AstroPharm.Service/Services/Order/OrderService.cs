using AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Mappers;
using AutoMapper;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;

public class OrderService : IOrderInterface
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        var order = _mapper.Map<Order>(dto);
        order.CreatedAt = DateTime.UtcNow;
        
        var result = await _orderRepository.InsertAsync(order);
        return _mapper.Map<OrderForResultDto>(result);
    }

    public async Task<IEnumerable<OrderForResultDto>> GetAllAsync()
    {
        var orders =  _orderRepository.SelectAll();
        return _mapper.Map<IEnumerable<OrderForResultDto>>(orders);
    }

    public async Task<OrderForResultDto> GetByIdAsync(long id)
    {
        var order = await _orderRepository.SelectByIdAsync(id);
        if (order == null)
            throw new AstroPharmException(404, "Order not found");
            
        return _mapper.Map<OrderForResultDto>(order);
    }

    public async Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto)
    {
        var existingOrder = await _orderRepository.SelectByIdAsync(id);
        if (existingOrder == null)
            throw new AstroPharmException(404, "Order not found");

        _mapper.Map(dto, existingOrder);
        existingOrder.UpdatedAt = DateTime.UtcNow;
        
        var result = await _orderRepository.UpdateAsync(existingOrder);
        return _mapper.Map<OrderForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var order = await _orderRepository.SelectByIdAsync(id);
        if (order == null)
            throw new AstroPharmException(404, "Order not found");

        return await _orderRepository.DeleteAsync(id);
    }
}