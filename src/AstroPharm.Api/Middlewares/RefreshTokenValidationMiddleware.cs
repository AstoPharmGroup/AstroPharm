using AstroPharm.Data.IRepositories;

public class RefreshTokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public RefreshTokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IRepository<RefreshToken> refreshTokenRepository)
    {
        if (context.Request.Path.StartsWithSegments("/api/auth/Authentificate") || context.Request.Path.StartsWithSegments("/api/Users/Add"))
        {
            await _next(context); 
            return;
        }


        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new AstroPharm.Api.Helpers.Response
            {
                StatusCode = 401,
                Message = "Authorize to use this methods"
            });
            return;
        }


        var userId = Convert.ToInt64(context.User.FindFirst("Id").Value);

        var refreshTokens = refreshTokenRepository
            .SelectAll()
            .Where(u => u.UserId == userId);

        if (!refreshTokens.Any(u => !u.IsRevoked))
        {
            Console.WriteLine("logout working");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new AstroPharm.Api.Helpers.Response
                {
                    StatusCode = 401,
                    Message = "You are log out"
                });
            return;
        }

        await _next(context);
    }
}
