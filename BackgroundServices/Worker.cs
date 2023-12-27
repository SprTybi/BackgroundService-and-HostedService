namespace BackgroundServices
{
    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Worker running at: { DateTimeOffset.Now}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}




//short running

public class HostedWorker : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"Hosted running at: {DateTimeOffset.Now}");
                await Task.Delay(1000, cancellationToken);
            }
        });
        return Task.CompletedTask;
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
