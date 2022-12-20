using Microsoft.Extensions.DependencyInjection;
using Teste.Config;
using Teste.Vault;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var vault = new VaultConfig();
builder.Configuration.GetSection("Vault").Bind(vault);
builder.Services.AddSingleton<VaultConfig>(vault);

var sc = new SecureCardConfig();

if (vault.Ativo != null && vault.Ativo.Value)
{
    VaultReader.Bind(vault, sc);
}
else
{
    builder.Configuration.GetSection("SecureCard").Bind(sc);
}

builder.Services.AddSingleton<SecureCardConfig>(sc);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

