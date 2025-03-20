using AstroPharm.Service.DTOs.PharmacyBranchs;

namespace AstroPharm.Service.Interfaces.PharmacyBranchs
{
    public interface IPharmacyBranchInterface
    {
        Task<bool> RemoveAsync(long id);
        Task<PharmacyBranchForResultDto> GetByIdAsync(long id);
        Task<List<PharmacyBranchForResultDto>> GetAllAsync();
        Task<PharmacyBranchForResultDto> AddAsync(PharmacyBranchForCreationDto dto);
        Task<PharmacyBranchForResultDto> ModifyAsync(long id, PharmacyBranchForUpdateDto dto);
    }
}
