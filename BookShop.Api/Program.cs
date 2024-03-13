using BookShop.Api.Extensions;
using BookShop.Infrastucture.DbContexts;
using BookShop.Service.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureJwt(configuration);
builder.Services.AddSwaggerService();
builder.Services.AddCustomScopedService();
builder.Services.AddDbContext<BookShopDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Default"),
        o => { o.MigrationsAssembly("BookShop.Api"); });
    options.EnableSensitiveDataLogging();
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
