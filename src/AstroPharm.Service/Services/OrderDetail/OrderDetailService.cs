
using AutoMapper;
using AstroPharm.Domain.Entities;
using AstroPharm.Data.IRepositories;
using AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.Interfaces.Payments;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Exceptions;
public class OrderDetailService : IOrderDetail
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


    public async Task<OrderDetailForResult> AddAsync(OrderDetailForCreation dto)
    {
        var order = await orderService.GetByIdAsync(dto.OrderId)
            ?? throw new AstroPharmException(404, "Order not found");
        var med = await medicationService.GetByIdAsync(dto.MedicationId)
            ?? throw new AstroPharmException(404, "Medication not found");
        var payment = await paymentService.GetByIdAsync(dto.PaymentId)
            ?? throw new AstroPharmException(404, "Payment not found");

        var orderDetail = repository.InsertAsync(mapper.Map<OrderDetail>(dto));
        return mapper.Map<OrderDetailForResult>(orderDetail);
    }

    public async Task<IEnumerable<OrderDetailForResult>> GetAllAsync() => mapper.Map<IEnumerable<OrderDetailForResult>>(repository.SelectAll());

    public async Task<OrderDetailForResult> GetByIdAsync(long id)
    {
        var orderDetail = repository.SelectByIdAsync(id) ?? throw new AstroPharmException(404, "OrderDetailNotFound");
        return mapper.Map<OrderDetailForResult>(await orderDetail);
    }

    public async Task<OrderDetailForResult> ModifyAsync(long id, OrderDetailForUpdate dto)
    {
        var orderDetail = await repository.SelectByIdAsync(id)
            ?? throw new AstroPharmException(404, "OrderDetailNotFound");
        var order = await orderService.GetByIdAsync(dto.OrderId)
            ?? throw new AstroPharmException(404, "Order not found");
        var med = await medicationService.GetByIdAsync(dto.MedicationId)
            ?? throw new AstroPharmException(404, "Medication not found");
        var payment = await paymentService.GetByIdAsync(dto.PaymentId)
            ?? throw new AstroPharmException(404, "Payment not found");

        mapper.Map(dto, orderDetail);
        orderDetail.UpdatedAt = DateTime.Now;
        return mapper.Map<OrderDetailForResult>(await repository.UpdateAsync(orderDetail));
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var orderDetail = await repository.SelectByIdAsync(id)?? throw new AstroPharmException(404, "OrderDetailNotFound");

        return await repository.DeleteAsync(id);

    }
}