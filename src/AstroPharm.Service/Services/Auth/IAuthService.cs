public interface IAuthService
    {
        Task<LoginResultDto> AuthenticateAsync(LoginDto dto);
        Task LogoutAsync(long userId);
    }