using BackEnd_App.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    // File database akan otomatis terbuat dengan nama "activities.db" di folder proyek Anda
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // URL default milik Vite + ReactJS
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Diperlukan jika nanti Anda pakai Cookie/JWT Auth
    });
});

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Title = "Enterprise Web API Gateway";
        document.Info.Version = "v1.0.0 Stable";
        document.Info.Description = "High-performance RESTful API infrastructure engine powering the React.js Single Page Application. Built with .NET 8, Entity Framework Core, and embedded SQLite architecture.";

        // 🚀 Perbaikan di baris ini: Langsung instansiasi tanpa Microsoft.OpenApi.Models
        document.Info.Contact = new()
        {
            Name = "Fajar Maulana",
            Email = "fjrmaulana@yahoo.com",
            Url = new Uri("https://fajarsoft.com")
        };

        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
// 🚀 TAMBAHKAN KODE INI agar Swagger UI bisa diakses di browser
app.UseSwaggerUI(options =>
{
    // Mengarahkan Swagger UI untuk membaca file JSON yang dihasilkan oleh app.MapOpenApi()
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
    options.DocumentTitle = "Production-Ready Fullstack API Documentation";
});

// Jika ada yang mengakses root URL (http://localhost:5254/), otomatis dialihkan ke /swagger
app.MapGet("/", context => {
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");
app.UseAuthorization();

app.MapControllers();

var scoope = app.Services.CreateAsyncScope();
var service = scoope.ServiceProvider;
try {
    var context = service.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await BackEnd_App.Data.DbInitializer.SeedData(context);
}
catch (System.Exception ex)
{
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex,"Error Accured During Migration.");
}

app.Run();
