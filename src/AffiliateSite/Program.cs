using AffiliateSite.Extensions;
using AffiliateSite.Link;
using AffiliateSite.Users;
using AffiliateSite.WebApi;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddRemoteJsonConfig(builder.Configuration.GetSection("ConfigService").Get<string[]>());

builder.Host.UseSerilog((context, configuration) =>
{
    var excludesMessage = builder.Configuration.GetSection("ExcludesMessage").Get<string[]>();
    var excludesApiEndpoints = builder.Configuration.GetSection("ExcludesApiEndpoint").Get<string[]>();

    configuration
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .Filter.ByExcluding(c =>
            c.Properties.Any(p =>
                excludesApiEndpoints.Any(item => p.Value.ToString().Contains(item))
                || excludesMessage.Any(item => c.MessageTemplate.ToString().Contains(item))))
        .Enrich.WithExceptionDetails();
});

builder.Services
    .AddDatabaseConnection(builder.Configuration)
    .AddHttpContextAccessor()
    .AddScoped<CustomCookieAuthenticationEvents>()
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => 
    {
        option.Cookie.Name = ".AFF";
        option.ExpireTimeSpan = TimeSpan.FromDays(1);
        option.EventsType = typeof(CustomCookieAuthenticationEvents);
        option.Cookie.SameSite = SameSiteMode.Unspecified;
    });

builder.Services.AddMvcCore(
        options => options.Conventions.Add(new CommandConvention())
    )
    .AddUsersModule()
    .AddLinkModule();
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();
app.UseRequestLogMiddleware();
app.UseResponseLogMiddleware();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/health", async context =>
    {
        await context.Response.WriteAsync($"OK");
    });
    endpoints.MapControllers();
});

app.Run();
