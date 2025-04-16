using AstroPharm.Data.IRepositories;
using AstroPharm.Domain.Entities;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<RefreshToken> _refreshTokenRepository;

    public AuthService(ITokenService tokenService, IRepository<User> userRepository, IRepository<RefreshToken> refreshTokenRepository, IRepository<RefreshToken> accessTokenRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<LoginResultDto> AuthenticateAsync(LoginDto dto)
    {
        var user = await _userRepository.SelectAll().FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid email or password");

        var newAccessToken = _tokenService.GenerateToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            Token = newRefreshToken,
            ExpiryDate = DateTime.UtcNow.AddHours(2),
            UserId = user.Id,
        };

        await _refreshTokenRepository.InsertAsync(refreshTokenEntity);

        return new LoginResultDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
        };
    }


    public async Task LogoutAsync(long userId)
    {
        var refreshTokens = _refreshTokenRepository.SelectAll()
            .Where(u => u.UserId == userId && !u.IsRevoked && u.ExpiryDate > DateTime.UtcNow) 
            .ToList();

        if (!refreshTokens.Any())
            throw new InvalidOperationException("No active refresh tokens found for this user");

        foreach (var token in refreshTokens)
        {
            token.IsRevoked = true; 
            await _refreshTokenRepository.UpdateAsync(token); 
        }
    }


}
