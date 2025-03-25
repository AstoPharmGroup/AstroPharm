using AstroPharm.Service.DTOs.Medications;
using DemoProject.Domain.Configurations.Pagination;

namespace AstroPharm.Service.Interfaces.Medications
{
    public interface IMedicationInterface
    {
        Task<bool> DeleteAsync(long id);
        Task<MedicationForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<MedicationForResultDto>> GetAllAsync(PaginationParams @params);
        Task<MedicationForResultDto> AddAsync(MedicationForCreationDto dto);
        Task<MedicationForResultDto> ModifyAsync(long id, MedicationForUpdateDto dto);
    }
}
