namespace RTD.Web.Background;

public class FetchBackgroundService : BackgroundService
{
    public IServiceProvider Services { get; init; }
    private readonly ILogger<FetchBackgroundService> _logger;

    public FetchBackgroundService(IServiceProvider services, ILogger<FetchBackgroundService> logger)
    {
        Services = services;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
        }
    }
}