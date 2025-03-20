using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Delivery;
using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Service.DTOs.Deliveries;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Deliveries;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Deliveries;

public class DeliveryService : IDeliveryInterface
{
    private readonly IRepository<Delivery> repository;
    private readonly IRepository<Courier> courierRepository;
    private readonly IRepository<OrderDetail> orderRepository;
    private readonly IRepository<PharmacyStock> pharmacyStockRepository;
    private readonly IMapper mapper;

    public DeliveryService(
        IRepository<Delivery> repository,
        IRepository<Courier> courierRepository,
        IRepository<OrderDetail> orderRepository,
        IRepository<PharmacyStock> pharmacyStockRepository,
        IMapper mapper)
    {
        this.repository = repository;
        this.courierRepository = courierRepository;
        this.pharmacyStockRepository = pharmacyStockRepository;
        this.mapper = mapper;
        this.orderRepository = orderRepository;
    }

    public async Task<DeliveryForResultDto> AddAsync(DeliveryForCreationDto dto)
    {
        var stock = await pharmacyStockRepository.SelectAll()
               .FirstOrDefaultAsync(s => s.PharmacyBranchId == dto.PharmacyBranchId && s.MedicationId == dto.MedicationId);

        if (stock == null || stock.Quantity < dto.Quantity)
            throw new AstroPharmException(400, "Not enough stock available at the selected pharmacy branch!");

        stock.Quantity -= dto.Quantity;
        await pharmacyStockRepository.UpdateAsync(stock);

        var delivery = mapper.Map<Delivery>(dto);
        await repository.InsertAsync(delivery);

        return mapper.Map<DeliveryForResultDto>(delivery);
    }


    public async Task<DeliveryForResultDto> ModifyAsync(long id, DeliveryForUpdateDto dto)
    {
        var delivery = await repository.SelectByIdAsync(id);
        if (delivery == null)
            throw new AstroPharmException(404, "Delivery not found!");

        var stock = await pharmacyStockRepository.SelectAll()
              .FirstOrDefaultAsync(s => s.PharmacyBranchId == dto.PharmacyBranchId && s.MedicationId == dto.MedicationId);

        if (stock == null || stock.Quantity < dto.Quantity)
            throw new AstroPharmException(400, "Not enough stock available at the selected pharmacy branch!");

        var mapped = mapper.Map(dto, delivery);
        await repository.UpdateAsync(mapped);

        return mapper.Map<DeliveryForResultDto>(mapped);
    }

    public async Task<DeliveryForResultDto> GetByIdAsync(long id)
    {
        var delivery = await repository.SelectByIdAsync(id);
        if (delivery == null)
            throw new AstroPharmException(404, "Delivery not found!");

        return mapper.Map<DeliveryForResultDto>(delivery);
    }

    public async Task<IEnumerable<DeliveryForResultDto>> GetAllAsync()
    {
        var deliveries = await repository.SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return mapper.Map<IEnumerable<DeliveryForResultDto>>(deliveries);
    }
}
    