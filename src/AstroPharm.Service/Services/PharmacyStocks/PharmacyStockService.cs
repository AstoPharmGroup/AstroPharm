using AstroPharm.Service.Interfaces.PharmacyStocks;
using AstroPharm.Service.Exceptions;
using AutoMapper;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AstroPharm.Service.DTOs.PharmacyStocks;

public class PharmacyStockService : IPharmacyStockInterface
{
    private readonly IMapper _mapper;
    private readonly IRepository<PharmacyStock> _pharmacyStockRepository;
    private readonly IRepository<PharmacyBranch> _pharmacyBranchRepository;
    private readonly IRepository<Medication> _medicationRepository;

    public PharmacyStockService(
        IMapper mapper,
        IRepository<PharmacyStock> pharmacyStockRepository,
        IRepository<PharmacyBranch> pharmacyBranchRepository,
        IRepository<Medication> medicationRepository
    )
    {
        _mapper = mapper;
        _pharmacyStockRepository = pharmacyStockRepository;
        _pharmacyBranchRepository = pharmacyBranchRepository;
        _medicationRepository = medicationRepository;
    }

    public async Task<PharmacyStockForResult> AddAsync(PharmacyStockForCreationDto dto)
    {
        var branchExists = await _pharmacyBranchRepository.SelectByIdAsync(dto.PharmacyBranchId);
        if (branchExists is null)
            throw new AstroPharmException(404, "Pharmacy branch not found");

        var medicationExists = await _medicationRepository.SelectByIdAsync(dto.MedicationId);
        if (medicationExists is null)
            throw new AstroPharmException(404, "Medication not found");

        var stock = _mapper.Map<PharmacyStock>(dto);
        stock.CreatedAt = DateTime.UtcNow;

        return _mapper.Map<PharmacyStockForResult>(
            await _pharmacyStockRepository.InsertAsync(stock)
        );
    }

    public async Task<List<PharmacyStockForResult>> GetAllAsync()
    {
        var stocks = await _pharmacyStockRepository.SelectAll().ToListAsync();
        return _mapper.Map<List<PharmacyStockForResult>>(stocks);
    }

    public async Task<PharmacyStockForResult> GetByIdAsync(long id)
    {
        var stock = await _pharmacyStockRepository.SelectByIdAsync(id);
        if (stock is null)
            throw new AstroPharmException(404, "Pharmacy stock not found");

        return _mapper.Map<PharmacyStockForResult>(stock);
    }

    public async Task<PharmacyStockForResult> ModifyAsync(long id, PharmacyStockForUpdateDto dto)
    {
        var existingStock = await _pharmacyStockRepository.SelectByIdAsync(id);
        if (existingStock is null)
            throw new AstroPharmException(404, "Pharmacy stock not found");

        var branchExists = await _pharmacyBranchRepository.SelectByIdAsync(dto.PharmacyBranchId);
        if (branchExists is null)
            throw new AstroPharmException(404, "Pharmacy branch not found");

        var medicationExists = await _medicationRepository.SelectByIdAsync(dto.MedicationId);
        if (medicationExists is null)
            throw new AstroPharmException(404, "Medication not found");

        _mapper.Map(dto, existingStock);
        existingStock.UpdatedAt = DateTime.UtcNow;

        return _mapper.Map<PharmacyStockForResult>(
            await _pharmacyStockRepository.UpdateAsync(existingStock)
        );
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var stock = await _pharmacyStockRepository.SelectByIdAsync(id);
        if (stock is not null)
            return await _pharmacyStockRepository.DeleteAsync(id);

        throw new AstroPharmException(404, "Pharmacy stock not found");
    }
}
    