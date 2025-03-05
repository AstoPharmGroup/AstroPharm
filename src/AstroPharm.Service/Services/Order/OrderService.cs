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
        var user = await _userRepository.SelectByIdAsync(dto.UserId);

        if (user is null)
        {
            throw new AstroPharmException(404, "User not found");
        }
        else
        {
            var order = _mapper.Map<Order>(dto);

            order.CreatedAt = DateTime.UtcNow;

            return _mapper.Map<OrderForResultDto>(await _orderRepository.InsertAsync(order));
        }
    }

    public async Task<IEnumerable<OrderForResultDto>> GetAllAsync()
    {
        var orders = _orderRepository.SelectAll();
        return _mapper.Map<IEnumerable<OrderForResultDto>>(orders);
    }

    public async Task<OrderForResultDto> GetByIdAsync(long id)
    {
        var order = await _orderRepository.SelectByIdAsync(id);

        if (order is null)
            throw new AstroPharmException(404, "Order not found");

        return _mapper.Map<OrderForResultDto>(order);
    }

    public async Task<OrderForResultDto> ModifyAsync(long id, OrderForUpdateDto dto)
    {
        var user = await _userRepository.SelectByIdAsync(dto.UserId);

        var existingOrder = await _orderRepository.SelectByIdAsync(id);

        if (user is null)
        {
            throw new AstroPharmException(404, "User not found");
        }

        else if (existingOrder == null)
        {

            throw new AstroPharmException(404, "Order not found");
        }

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