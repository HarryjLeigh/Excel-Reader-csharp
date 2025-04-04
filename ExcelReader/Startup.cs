using ExcelReader.Controller;
using ExcelReader.Data;
using ExcelReader.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace ExcelReader;

public class Startup
{
    private readonly IConfiguration _configuration;
    internal readonly ServiceProvider _serviceProvider;

    public Startup()
    {
        _configuration = BuildConfiguration();
        _serviceProvider = ConfigureServices();
    }

    public void Configure()
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        SetupDatabase(dbContext);

        AnsiConsole.MarkupLine("[bold green]Database and table created successfully![/]");
    }

    private static IConfiguration BuildConfiguration()
    {
        string projectRootDirectory = Path.Combine(AppContext.BaseDirectory, "../../../");

        return new ConfigurationBuilder()
            .SetBasePath(projectRootDirectory)
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
    

    private ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<MovieController>();

        return services.BuildServiceProvider();
    }

    private static void SetupDatabase(AppDbContext dbContext)
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
}