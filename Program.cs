using ListaDeCompras.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Injeção de dependência do banco de dados.
builder.Services.AddDbContext<BancoContext>(options
    => options.UseMySql(builder.Configuration.GetConnectionString("DataBase"), ServerVersion.Parse("8.0")));

builder.Services.AddRazorPages();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
