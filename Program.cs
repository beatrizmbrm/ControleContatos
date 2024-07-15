using ControleContatos.Data;
using ControleContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseMySql(
        "server=localhost;initial catalog=CRUDControle;uid=root;pwd=102938",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.38-mysql")));

builder.Services.AddScoped<IContatoRepositorios, ContatoRepositorio>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contato}/{action=Contato}/{id?}");

app.Run();
