using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;
    private readonly HttpClient _httpClient;

    private const string BotToken = "7232218961:AAF5rGUQQaYVQRfRHN93-7K5AmKR6WBRhO0";
    private const string ChatId = "1333252980";

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
        _httpClient = new HttpClient();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();

        var logMessage = $"📡 API Request:\n" +
                         $"🔹 Method: {context.Request.Method}\n" +
                         $"🔹 Path: {context.Request.Path}\n" +
                         $"🔹 Response: {context.Response.StatusCode}\n" +
                         $"⏳ Time: {stopwatch.ElapsedMilliseconds} ms";

        _logger.LogInformation(logMessage);

        await SendMessageToTelegram(logMessage);
    }

    private async Task SendMessageToTelegram(string message)
    {
        var url = $"https://api.telegram.org/bot{BotToken}/sendMessage";
        var data = new Dictionary<string, string>
        {
            { "chat_id", ChatId },
            { "text", message }
        };

        await _httpClient.PostAsync(url, new FormUrlEncodedContent(data));
    }
}
