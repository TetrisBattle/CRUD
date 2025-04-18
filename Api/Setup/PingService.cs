using Npgsql;

namespace Api.Setup;

public class PingService(IConfiguration configuration) : IHostedService, IDisposable
{
    private Timer? _timer; // Make _timer nullable since it is initialized later
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("DefaultConnection string is not configured.");

	public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(PingDatabase, null, TimeSpan.Zero, TimeSpan.FromDays(7));
        return Task.CompletedTask;
    }

    private void PingDatabase(object? state) // Allow nullable state to match TimerCallback delegate
    {
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var cmd = new NpgsqlCommand("SELECT 1;", connection);
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            // Handle exception (optional)
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
        GC.SuppressFinalize(this);
    }
}
