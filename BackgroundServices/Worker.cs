namespace BackgroundServices
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}




//short running

public class HostedWorker : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"Hosted running at: {DateTimeOffset.Now}");
            await Task.Delay(1000, cancellationToken);
        }
    }
    // public Task StartAsync(CancellationToken cancellationToken)
    //{
    //    Console.WriteLine($"Hosted running at: {DateTimeOffset.Now}");

    //    return Task.CompletedTask;
    //}

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"---------Hosted running at: {DateTimeOffset.Now} Ended------------");
        return Task.CompletedTask;
    }
}
