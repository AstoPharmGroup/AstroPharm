using AstroPharm.Service.Interfaces.PharmacyBranchs;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Mappers;
using AutoMapper;
using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.Pharmacy;
using Microsoft.EntityFrameworkCore;
using AstroPharm.Service.DTOs.PharmacyBranchs;

public class PharmacyBranchService : IPharmacyBranchInterface
{
    private readonly IMapper _mapper;
    private readonly IRepository<PharmacyBranch> _pharmacyBranchRepository;

    public PharmacyBranchService(
        IMapper mapper,
        IRepository<PharmacyBranch> pharmacyBranchRepository
    )
    {
        _mapper = mapper;
        _pharmacyBranchRepository = pharmacyBranchRepository;
    }

    public async Task<PharmacyBranchForResultDto> AddAsync(PharmacyBranchForCreationDto dto)
    {
        var pharmacyBranch = _mapper.Map<PharmacyBranch>(dto);
        pharmacyBranch.CreatedAt = DateTime.UtcNow;

        return _mapper.Map<PharmacyBranchForResultDto>(
            await _pharmacyBranchRepository.InsertAsync(pharmacyBranch)
        );
    }

    public async Task<List<PharmacyBranchForResultDto>> GetAllAsync()
    {
        var branches = await _pharmacyBranchRepository.SelectAll().ToListAsync();
        return _mapper.Map<List<PharmacyBranchForResultDto>>(branches);
    }

    public async Task<PharmacyBranchForResultDto> GetByIdAsync(long id)
    {
        var branch = await _pharmacyBranchRepository.SelectByIdAsync(id);
        if (branch is null)
            throw new AstroPharmException(404, "Pharmacy branch not found");

        return _mapper.Map<PharmacyBranchForResultDto>(branch);
    }

    public async Task<PharmacyBranchForResultDto> ModifyAsync(long id, PharmacyBranchForUpdateDto dto)
    {
        var existingBranch = await _pharmacyBranchRepository.SelectByIdAsync(id);
        if (existingBranch is null)
            throw new AstroPharmException(404, "Pharmacy branch not found");

        _mapper.Map(dto, existingBranch);
        existingBranch.UpdatedAt = DateTime.UtcNow;

        return _mapper.Map<PharmacyBranchForResultDto>(
            await _pharmacyBranchRepository.UpdateAsync(existingBranch)
        );
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var branch = await _pharmacyBranchRepository.SelectByIdAsync(id);
        if (branch is not null)
            return await _pharmacyBranchRepository.DeleteAsync(id);

        throw new AstroPharmException(404, "Pharmacy branch not found");
    }

}
