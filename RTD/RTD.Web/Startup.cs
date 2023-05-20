using Microsoft.EntityFrameworkCore;
using RTD.Web.Background;
using RTD.Web.Engine.EF;

namespace RTD.Web;

public static class Startup
{
    public static void AddDependencies(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("Sqlite").Get<string?>() ?? "Data Source=RTD.db";
        services.AddDbContext<RssDbContext>(options => options.UseSqlite(connectionString));
        
        services.AddHostedService<FetchBackgroundService>();
    }
}