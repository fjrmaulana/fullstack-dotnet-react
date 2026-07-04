var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
if (app.Environment.IsDevelopment())
{
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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
