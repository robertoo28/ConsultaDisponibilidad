using ConsultaDisponibilidad;
using ConsultaDisponibilidad.Data;
using ConsultaDisponibilidad.Model;
using ConsultaDisponibilidad.Services;
using Microsoft.EntityFrameworkCore;
using SoapCore;
using SoapCore.Extensibility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    ));

// Register the IAvailabilityService implementation
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();

// Register the custom IFaultExceptionTransformer service
builder.Services.AddSingleton<IFaultExceptionTransformer, CustomFaultExceptionTransformer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IAvailabilityService>(
        "/AvailabilityService.asmx",
        new SoapEncoderOptions[] { new SoapEncoderOptions() }
    );
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();