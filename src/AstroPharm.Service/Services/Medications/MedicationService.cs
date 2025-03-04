using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Medications;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Medications
{
    public class MedicationService : IMedicationInterface
    {
        private readonly IRepository<Medication> repository;
        private readonly IMapper mapper;

        public MedicationService(IMapper mapper , IRepository<Medication> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        
        public async Task<MedicationForResultDto> AddAsync(MedicationForCreationDto dto)
        {
            var medication =await repository.SelectAll()
                .Where(x => x.MedicationName == dto.MedicationName)
                .FirstOrDefaultAsync();
            if(medication != null)
                throw new AstroPharmException(409, "This medication already exists");

            var mapped = mapper.Map<Medication>(dto);
            await repository.InsertAsync(mapped);

            return mapper.Map<MedicationForResultDto>(mapped);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var medication = await repository.SelectByIdAsync(id);
            if (medication == null)
                throw new AstroPharmException(404, "Medication not found!");

            await repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<MedicationForResultDto>> GetAllAsync()
        {
            var medications = await repository.SelectAll()
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<IEnumerable<MedicationForResultDto>>(medications);
        }

        public async Task<MedicationForResultDto> GetByIdAsync(long id)
        {
            var medication = await repository.SelectByIdAsync(id);
            if (medication == null)
                throw new AstroPharmException(404, "Medication not found!");

            return mapper.Map<MedicationForResultDto>(medication);
        }

        public async Task<MedicationForResultDto> ModifyAsync(long id, MedicationForUpdateDto dto)
        {
            var medication = await repository.SelectByIdAsync(id);
            if (medication == null)
                throw new AstroPharmException(404, "Medication not found!");

            mapper.Map(dto, medication);
            await repository.UpdateAsync(medication);

            return mapper.Map<MedicationForResultDto>(medication);
        }
    }
}
