using Microsoft.EntityFrameworkCore;
using SaborDoBrasil;
using SaborDoBrasil.Model;
using SaborDoBrasil.Data; // Adicione este using para acessar o AppDbContext

var builder = WebApplication.CreateBuilder(args);

// Configuração do serviço do AppDbContext com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

var app = builder.Build();

app.UseDefaultFiles(); // Serve index.html por padrão
app.UseStaticFiles(); // Permite servir arquivos da pasta wwwroot

app.MapGet("/index", async context =>
{
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();