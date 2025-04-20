using AutoMapper;
using AstroPharm.Domain.Entities;
using AstroPharm.Data.IRepositories;
using AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.Interfaces.Payments;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.OrderDetails;
using AstroPharm.Service.DTOs.OrderDetails;
using Microsoft.EntityFrameworkCore;
using AstroPharm.Domain.Entities.Orders;
public class OrderDetailService : IOrderDetailInterface
{
    private readonly IMapper mapper;
    private readonly IRepository<OrderDetail> repository;
    private readonly IOrderInterface orderService;
    private readonly IPaymentInterface paymentService;
    private readonly IMedicationInterface medicationService;

    public OrderDetailService(IMapper mapper, IRepository<OrderDetail> repository, IMedicationInterface medicationService, IPaymentInterface paymentService, IOrderInterface orderService)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.orderService = orderService;
        this.paymentService = paymentService;
        this.medicationService = medicationService;
    }

    public async Task<OrderDetailForResultDto> AddAsync(OrderDetailForCreationDto dto)
    {
        var order = await orderService.GetByIdAsync(dto.OrderId)
            ?? throw new AstroPharmException(404, "Order not found");
        var med = await medicationService.GetByIdAsync(dto.MedicationId)
            ?? throw new AstroPharmException(404, "Medication not found");
        var payment = await paymentService.GetByIdAsync(dto.PaymentId)
            ?? throw new AstroPharmException(404, "Payment not found");

        decimal totalPriceBeforeDiscount = med.Price * dto.Quantity;
        decimal discountAmount = totalPriceBeforeDiscount * (dto.Discount / 100);
        decimal totalAmount = totalPriceBeforeDiscount - discountAmount;


        var orderDetail = mapper.Map<OrderDetail>(dto);
        orderDetail.TotalAmount = totalAmount; 

        var insertedOrderDetail = await repository.InsertAsync(orderDetail);

        return mapper.Map<OrderDetailForResultDto>(orderDetail);
    }


    public async Task<IEnumerable<OrderDetailForResultDto>> GetAllAsync()
    {
        var orderDetails = await repository.SelectAll().ToListAsync();
        return mapper.Map<IEnumerable<OrderDetailForResultDto>>(orderDetails);
    }


    public async Task<OrderDetailForResultDto> GetByIdAsync(long id)
    {
        var orderDetail = repository.SelectByIdAsync(id) ?? throw new AstroPharmException(404, "OrderDetailNotFound");
        return mapper.Map<OrderDetailForResultDto>(await orderDetail);
    }

    public async Task<OrderDetailForResultDto> ModifyAsync(long id, OrderDetailForUpdateDto dto)
    {
        var orderDetail = await repository.SelectByIdAsync(id)
            ?? throw new AstroPharmException(404, "OrderDetailNotFound");
        var order = await orderService.GetByIdAsync(dto.OrderId)
            ?? throw new AstroPharmException(404, "Order not found");
        var med = await medicationService.GetByIdAsync(dto.MedicationId)
            ?? throw new AstroPharmException(404, "Medication not found");
        var payment = await paymentService.GetByIdAsync(dto.PaymentId)
            ?? throw new AstroPharmException(404, "Payment not found");

        decimal totalPriceBeforeDiscount = med.Price * dto.Quantity;
        decimal discountAmount = totalPriceBeforeDiscount * (dto.Discount / 100);
        decimal totalAmount = totalPriceBeforeDiscount - discountAmount;

        mapper.Map(dto, orderDetail);
        orderDetail.TotalAmount = totalAmount;
        orderDetail.UpdatedAt = DateTime.Now;
        return mapper.Map<OrderDetailForResultDto>(await repository.UpdateAsync(orderDetail));
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var orderDetail = await repository.SelectByIdAsync(id) ?? throw new AstroPharmException(404, "OrderDetailNotFound");

        return await repository.DeleteAsync(id);

    }
}
