using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.Products;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Categories;
using AstroPharm.Service.Interfaces.Medications;
using AutoMapper;
using DemoProject.Domain.Configurations;
using DemoProject.Domain.Configurations.Pagination;
using FuzzySharp;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Medications
{
    public class MedicationService : IMedicationInterface
    {
        private readonly IMapper mapper;
        private readonly IRepository<Medication> repository;
        private readonly ICategoryInterface categoryInterface;

        public MedicationService(
            IMapper mapper,
            IRepository<Medication> repository,
            ICategoryInterface category)
        {
            this.mapper = mapper;
            this.repository = repository;
            categoryInterface = category;
        }

        public async Task<MedicationForResultDto> AddAsync(MedicationForCreationDto dto)
        {
            var category = await categoryInterface.GetByIdAsync(dto.CategoryId);
            if (category == null)
                throw new AstroPharmException(404, "Category not found!");

            var medication = await repository.SelectAll()
                .Where(x => x.MedicationName == dto.MedicationName)
                .FirstOrDefaultAsync();
            if (medication != null)
                throw new AstroPharmException(409, "This medication already exists");

            var mapped = mapper.Map<Medication>(dto);

            if (dto.Image != null)
            {
                var folderPath = Path.Combine("wwwroot", "medication");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                mapped.Image = Path.Combine("medication", fileName); 
            }

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

        public async Task<IEnumerable<MedicationForResultDto>> GetAllAsync(PaginationParams @params)
        {
            var medications = await repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
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

            var category = await categoryInterface.GetByIdAsync(dto.CategoryId);
            if (category == null)
                throw new AstroPharmException(404, "Category not found!");

            mapper.Map(dto, medication);

            if (dto.Image != null)
            {
                var folderPath = Path.Combine("wwwroot", "medication");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                medication.Image = Path.Combine("medication", fileName); 
            }

            await repository.UpdateAsync(medication);

            return mapper.Map<MedicationForResultDto>(medication);
        }


        public async Task<List<MedicationForResultDto>> SearchAsync(string searchTerm)
        {
            var medications = await repository.SelectAll().ToListAsync();

            

            var fuzzyResults = medications
                  .Select(medication => new
                  {
                      Medication = medication,
                      Score = Fuzz.PartialRatio(medication.MedicationName.ToLower(), searchTerm.ToLower())  
                  })
                  .Where(result => result.Score >= 80) 
                  .OrderByDescending(result => result.Score)
                  .ToList();

            return mapper.Map<List<MedicationForResultDto>>(fuzzyResults.Select(m => m.Medication).ToList());
        }

    }
}
