using AstroPharm.Domain.Entities;

public interface ITokenService
{
    public string GenerateToken(User user);
    public string GenerateRefreshToken();
}