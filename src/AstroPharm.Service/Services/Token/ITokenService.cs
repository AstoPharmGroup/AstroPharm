using AstroPharm.Domain.Entities.Users;

public interface ITokenService
{
    public string GenerateToken(User user);
    public string GenerateRefreshToken();
}