using System.Text;
using Hangfire;
using Hangfire.SqlServer;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WebApiDotnet.Data;
using Serilog;
using WebApiDotnet.filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApiDotnet.Entities;
using WebApiDotnet.Repositories;
using WebApiDotnet.Repositories.Interfaces;
using WebApiDotnet.Repositories.Player;

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

    #region Swagger
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });
            
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
    });
    #endregion

    # region Database

    builder.Services.AddDbContext<WebApiDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

    builder.Services.AddScoped<IBaseRepository<PlayerEntity>, PlayerRepository>();
    builder.Services.AddScoped<IBaseRepository<PlayerBankEntity>, PlayerBankRepository>();
    builder.Services.AddScoped<IBaseRepository<PlayerBillEntity>, PlayerBillRepository>();
    
    builder.Services.AddScoped<IBaseRepository<GameEntity>, GameRepository>();
    builder.Services.AddScoped<IBaseRepository<GoalEntity>, GoalRepository>();
    
    builder.Services.AddScoped<IBaseRepository<PlayerGameEntity>, PlayerGameRepository>();
    
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

    #region Claims

    builder.Services.AddIdentity<UserEntity, IdentityRole>( o =>
    {
        o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.User.RequireUniqueEmail = true;
    }).AddEntityFrameworkStores<WebApiDbContext>() ;

    
    #endregion

    #region AutoMapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    #endregion
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

    app.UseAuthentication();
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
