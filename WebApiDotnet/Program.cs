using Hangfire;
using Hangfire.SqlServer;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using WebApiDotnet.Repositories;
using Serilog;
using WebApiDotnet.filters;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    #region Logger

    var logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.File("logs/webapilogs.log")
        .WriteTo.Console()
        .CreateLogger();

    Log.Logger = logger;

    builder.Services.AddSingleton<Serilog.ILogger>(logger);
    // builder.Services.AddScoped() ?? 

    #endregion

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    # region Database

    builder.Services.AddDbContext<WebApiContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

    builder.Services.AddScoped<IUserRepository, UserRepository>();

    #endregion

    # region Hangfire

    builder.Services.AddHangfire((provider, configuration) =>
    {
        configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(builder.Configuration.GetConnectionString("DataBase"), new SqlServerStorageOptions()
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            });

        configuration.UseFilter(new AutomaticRetryAttribute
            { Attempts = 2, DelaysInSeconds = new int[] { 60, 120, 240 } });
    });
    builder.Services.AddHangfireServer();


    #endregion

    #region MassTransit

    var connectionString = config.GetConnectionString("rabbitmq");

    builder.Services.AddMassTransit(x =>
    {
        x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(connectionString!));
            cfg.ReceiveEndpoint("DefaultQueue", ep =>
            {
                ep.PrefetchCount = 10;
                ep.UseMessageRetry(r => r.Interval(2, 100));
            });
        }));
    });

    #endregion


    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    var app = builder.Build();

    #region Hangfire Dashboard

    app.MapHangfireDashboard("/hangfire/dashboard", new DashboardOptions()
    {
        Authorization = new[]
        {
            new HangfireDashboardFilter()
        }
    });

    #endregion


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
