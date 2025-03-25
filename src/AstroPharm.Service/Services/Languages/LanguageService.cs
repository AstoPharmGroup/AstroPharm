using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Languages;
using AstroPharm.Service.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class LanguageService : ILanguageInterface
{
    private readonly IRepository<Language> _languageRepository;
    private readonly IMapper _mapper;

    public LanguageService(IRepository<Language> languageRepository, IMapper mapper)
    {
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<Language> AddAsync(LanguageForCreationDto dto)
    {
        var existingLanguage = await _languageRepository.SelectAll()
            .FirstOrDefaultAsync(l => l.LanguageName == dto.LanguageName);

        if (existingLanguage != null)
            throw new AstroPharmException(409, "This Language already exists");

        var language = _mapper.Map<Language>(dto);
        await _languageRepository.InsertAsync(language);

        return language;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var language = await _languageRepository.SelectByIdAsync(id);
        if (language == null)
            throw new AstroPharmException(404, "Language not found!");

        await _languageRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<Language>> GetAllAsync()
    {
        return await _languageRepository.SelectAll().ToListAsync();
    }

    public async Task<Language> GetByIdAsync(long id)
    {
        var language = await _languageRepository.SelectByIdAsync(id);
        if (language == null)
            throw new AstroPharmException(404, "Language not found!");

        return language;
    }

    public async Task<Language> ModifyAsync(long id, LanguageForUpdateDto dto)
    {
        var language = await _languageRepository.SelectByIdAsync(id);
        if (language == null)
            throw new AstroPharmException(404, "Language not found!");

        _mapper.Map(dto, language);
        await _languageRepository.UpdateAsync(language);

        return language;
    }
}
