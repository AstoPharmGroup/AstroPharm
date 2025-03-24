using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.Exceptions;
using AstroPharm.Service.Interfaces.Banners;
using AstroPharm.Service.Interfaces.Categories;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Services.Categories;
using AstroPharm.Service.Services.Medications;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Service.Services.Banners;

public class BannerService : IBannerInterface
{
    private readonly IRepository<Banner> _bannerRepository;
    private readonly IMedicationInterface _medicationService;
    private readonly ICategoryInterface _categoryService;
    private readonly IMapper _mapper;

    public BannerService(IRepository<Banner> bannerRepository, IMapper mapper, IMedicationInterface medicationService, ICategoryInterface categoryService)
    {
        _bannerRepository = bannerRepository;
        _mapper = mapper;
        _medicationService = medicationService;
        _categoryService = categoryService;
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

        var mapped = _mapper.Map<Banner>(dto);
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

        var mapped = _mapper.Map(dto, banner);
        await _bannerRepository.UpdateAsync(mapped);

        return _mapper.Map<BannerForResultDto>(mapped);
    }
}
