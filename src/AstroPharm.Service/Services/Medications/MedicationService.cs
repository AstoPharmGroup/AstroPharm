using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Categories;
using AstroPharm.Service.Interfaces.Medications;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Medications
{
    public class MedicationService : IMedicationInterface
    {
        private readonly IMapper mapper;
        private readonly IRepository<Medication> repository;
        private readonly ICategoryInterface categoryInterface;
        private readonly IWebHostEnvironment _environment;

        public MedicationService(
            IMapper mapper,
            IRepository<Medication> repository,
            ICategoryInterface category,
            IWebHostEnvironment environment)
        {
            this.mapper = mapper;
            this.repository = repository;
            categoryInterface = category;
            _environment = environment;
        }
        public async Task<MedicationForResultDto> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new AstroPharmException(400, "Error while uploading image!");


            var medicationFolder = Path.Combine(_environment.WebRootPath, "medications");
            Directory.CreateDirectory(medicationFolder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(medicationFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"/medications/{fileName}";
            return new MedicationForResultDto { Image = fileUrl };
        }

        public async Task<MedicationForResultDto> AddAsync(MedicationForCreationDto dto)
        {
            var category = await categoryInterface.GetByIdAsync(dto.CategoryId);
            if (category == null)
                throw new AstroPharmException(404, "Categpry not found!");

            var medication = await repository.SelectAll()
                .Where(x => x.MedicationName == dto.MedicationName)
                .FirstOrDefaultAsync();
            if (medication != null)
                throw new AstroPharmException(409, "This medication already exists");

            string imageUrl = null;
            if (dto.File != null)
            {
                var uploadedImage = await UploadImage(dto.File);
                imageUrl = uploadedImage.Image;
            }

            var mapped = mapper.Map<Medication>(dto);
            mapped.Image = imageUrl;

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
                //.AsNoTracking()
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
                throw new AstroPharmException(404, "Categpry not found!");

            string imageUrl = null;
            if (dto.File != null)
            {
                var uploadedImage = await UploadImage(dto.File);
                imageUrl = uploadedImage.Image;
            }

            var mapped = mapper.Map(dto, medication);
            mapped.Image = imageUrl;

            await repository.UpdateAsync(medication);
            return mapper.Map<MedicationForResultDto>(medication);
        }
    }
}
