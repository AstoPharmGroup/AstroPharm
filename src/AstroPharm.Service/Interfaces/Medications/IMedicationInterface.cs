using AstroPharm.Service.DTOs.Medications;

namespace AstroPharm.Service.Interfaces.Medications
{
    public interface IMedicationInterface
    {
        Task<bool> DeleteAsync(long id);
        Task<MedicationForResultDto> GetByIdAsync(long id);
        Task<IEnumerable<MedicationForResultDto>> GetAllAsync();
        Task<MedicationForResultDto> AddAsync(MedicationForCreationDto dto);
        Task<MedicationForResultDto> ModifyAsync(long id, MedicationForUpdateDto dto);
    }
}
