using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Banners;
using AstroPharm.Service.Interfaces.Categories;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Services.Categories;
using AstroPharm.Service.Services.Medications;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Banners;

public class BannerService : IBannerInterface
{
    private readonly IRepository<Banner> _bannerRepository;
    private readonly IMedicationInterface _medicationService;
    private readonly ICategoryInterface _categoryService;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;

    public BannerService(IRepository<Banner> bannerRepository, IMapper mapper, IMedicationInterface medicationService, ICategoryInterface categoryService, IWebHostEnvironment environment)
    {
        _bannerRepository = bannerRepository;
        _mapper = mapper;
        _medicationService = medicationService;
        _categoryService = categoryService;
        _environment = environment;
    }
    public async Task<MedicationForResultDto> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new AstroPharmException(400, "Error while uploading image!");


        var medicationFolder = Path.Combine(_environment.WebRootPath, "media/banners");
        Directory.CreateDirectory(medicationFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(medicationFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var fileUrl = $"media/banners/{fileName}";
        return new MedicationForResultDto { Image = fileUrl };
    }

    public async Task<BannerForResultDto> AddAsync(BannerForCreationDto dto)
    {
        var banner = await _bannerRepository.SelectAll()
            .Where(x => x.Title == dto.Title)
            .FirstOrDefaultAsync();

        if (banner != null)
            throw new AstroPharmException(409, "This banner already exists");

        var categoryExist = await _categoryService.GetByIdAsync(dto.CategoryId);
        var medicationExist = await _medicationService.GetByIdAsync(dto.MedicationId);

        if (categoryExist == null || medicationExist == null)
            throw new AstroPharmException(404, "Medication or Category with this id doesnt exist");

        string imageUrl = null;
        if (dto.File != null)
        {
            var uploadedImage = await UploadImage(dto.File);
            imageUrl = uploadedImage.Image;
        }

        var mapped = _mapper.Map<Banner>(dto);
        mapped.Image = imageUrl;
        await _bannerRepository.InsertAsync(mapped);

        return _mapper.Map<BannerForResultDto>(mapped);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var banner = await _bannerRepository.SelectByIdAsync(id);
        if (banner == null)
            throw new AstroPharmException(404, "Banner not found!");

        await _bannerRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<BannerForResultDto>> GetAllAsync()
    {
        var banners = await _bannerRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<BannerForResultDto>>(banners);
    }

    public async Task<BannerForResultDto> GetByIdAsync(long id)
    {
        var banner = await _bannerRepository.SelectByIdAsync(id);
        if (banner == null)
            throw new AstroPharmException(404, "Banner not found!");

        return _mapper.Map<BannerForResultDto>(banner);
    }

    public async Task<BannerForResultDto> ModifyAsync(long id, BannerForUpdateDto dto)
    {
        var banner = await _bannerRepository.SelectByIdAsync(id);
        if (banner == null)
            throw new AstroPharmException(404, "Banner not found!");

        var categoryExist = await _categoryService.GetByIdAsync(dto.CategoryId);
        var medicationExist = await _medicationService.GetByIdAsync(dto.MedicationId);

        if (categoryExist == null || medicationExist == null)
            throw new AstroPharmException(404, "Medication or Category with this id doesnt exist");

        string imageUrl = null;
        if (dto.File != null)
        {
            var uploadedImage = await UploadImage(dto.File);
            imageUrl = uploadedImage.Image;
        }

        var mapped = _mapper.Map(dto, banner);
        mapped.Image = imageUrl;

        await _bannerRepository.UpdateAsync(mapped);
        return _mapper.Map<BannerForResultDto>(mapped);
    }
}
