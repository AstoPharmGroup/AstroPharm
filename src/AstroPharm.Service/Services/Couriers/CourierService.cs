using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.Delivery;
using AstroPharm.Service.DTOs.Couriers;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Couriers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Couriers;

public class CourierService : ICourierInterface
{
    private readonly IRepository<Courier> repository;
    private readonly IMapper mapper;

    public CourierService(IRepository<Courier> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<CourierForResultDto> AddAsync(CourierForCreationDto dto)
    {
        var existingCourier = await repository.SelectAll()
            .Where(x => x.Phone == dto.Phone)
            .FirstOrDefaultAsync();

        if (existingCourier != null)
            throw new AstroPharmException(400, "Courier with this phone already exists!");

        var newCourier = mapper.Map<Courier>(dto);
        newCourier.CreatedAt = DateTime.UtcNow;
        await repository.InsertAsync(newCourier);

        return mapper.Map<CourierForResultDto>(newCourier);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var courier = await repository.SelectByIdAsync(id);
        if (courier == null)
            throw new AstroPharmException(404, "Courier not found!");

        await repository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<CourierForResultDto>> GetAllAsync()
    {
        var couriers = await repository.SelectAll().ToListAsync();
        return mapper.Map<IEnumerable<CourierForResultDto>>(couriers);
    }

    public async Task<CourierForResultDto> GetByIdAsync(long id)
    {
        var courier = await repository.SelectByIdAsync(id);
        if (courier == null)
            throw new AstroPharmException(404, "Courier not found!");

        return mapper.Map<CourierForResultDto>(courier);
    }

    public async Task<CourierForResultDto> ModifyAsync(long id, CourierForUpdateDto dto)
    {
        var courier = await repository.SelectByIdAsync(id);
        if (courier == null)
            throw new AstroPharmException(404, "Courier not found!");

        var modifiedCourier = mapper.Map(dto, courier);
        modifiedCourier.UpdatedAt = DateTime.UtcNow;
        await repository.UpdateAsync(modifiedCourier);

        return mapper.Map<CourierForResultDto>(modifiedCourier);
    }
}
