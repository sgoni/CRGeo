var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);
builder.Host.UseSerilog();

var app = builder.Build();

ConfigureMiddleware(app);
app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    });

    // Add Carter
    services.AddCarter();

    // Add Exception Handler
    services.AddExceptionHandler<CustomExceptionHandler>();

    services.AddSingleton<DapperContext>();
    services.AddScoped<IGeoRepository, GeoRepository>();

    // Add Serilog
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .Enrich.FromLogContext()
        .CreateLogger();

    // Add Health Checks
    services
        .AddHealthChecks()
        .AddApplicationStatus("api_status", tags: new[] { "api" })
        .AddNpgSql(configuration.GetConnectionString("Database")!,
            name: "sql",
            failureStatus: HealthStatus.Degraded,
            tags: new[] { "db", "sql", "sqlserver" });

    // Add Controllers
    services.AddControllers();
    services.AddAuthorization();

    // Add Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // MapsterConfig
    MapsterConfig.RegisterProvinceMapping();
    MapsterConfig.RegisteGeographicalDistributionMapping();
}

void ConfigureMiddleware(WebApplication app)
{
    // Map Carter Endpoints
    app.MapCarter();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRGeo.BackEnd.API v1.0"));
    }

    // Add Middleware
    app.UseRouting();
    app.UseAuthentication(); // Si usas autenticación
    app.UseAuthorization(); // Esto requiere AddAuthorization()

    // Map Controllers
    app.MapControllers();

    // Use Exception Handler
    app.UseExceptionHandler(options => { });

    // Add Health Checks
    app.UseHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
}