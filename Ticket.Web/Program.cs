using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ticket.Web.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TicketZone API", Version = "v1" });
});

// MVC + DB
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles(); // <-- importante para HTML en wwwroot
app.MapControllers();

// Swagger + Redirección
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketZone API v1");
    });

    // Redirigir la raíz a Login.html
    app.MapGet("/", context =>
    {
        context.Response.Redirect("/Login.html");
        return Task.CompletedTask;
    });

    // Abrir ambas URLs automáticamente al iniciar (solo una vez)
    Task.Run(() =>
    {
        var swaggerUrl = "http://localhost:5280/swagger";
        var htmlUrl = "http://localhost:5280/Login.html";

        // Solo abrimos Swagger aquí porque Login ya lo abre launchSettings.json
        Process.Start(new ProcessStartInfo { FileName = swaggerUrl, UseShellExecute = true });
    });
}

app.Run();
