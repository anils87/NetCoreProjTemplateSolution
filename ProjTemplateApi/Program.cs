using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ProjTemplateCommon.Extensions;
using ProjTemplateService;

var builder = WebApplication.CreateBuilder(args);

//builder.Logging.AddConsole();

// Enable ApplicationInsights Logging
builder.Services.AddApplicationInsightsTelemetry();
//Enable Database query monitoring in Applicatipn Insights
builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>
{
    module.EnableSqlCommandTextInstrumentation = true;
});

// Add services to the container.
builder.Services.AddAuthentication();

// Add CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins(new[] { "http://*", "https://*" }).AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Standard Services
builder.Services.UseProjTemplateServices(builder.Configuration);
builder.Services.AddCommonAuthorization(builder.Configuration);
builder.Services.AddCommonCoreAPIAuthorization();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

#pragma warning disable ASP0000
//var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
//var headerContext = builder.Services.BuildServiceProvider().GetRequiredService<HeaderSecurityContext>();
#pragma warning restore ASP0000

app.UseCors("AllowAll");

// Configure Common Standard Middleware
app.UseCommonApp(app.Environment);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
