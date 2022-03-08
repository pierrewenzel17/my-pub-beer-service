using Microsoft.EntityFrameworkCore;
using MyPubBeerService.Api.Data;
using MyPubBeerService.Api.Repositories;
using MyPubBeerService.Api.Services;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeerServiceDbContext>(opt => opt.UseInMemoryDatabase("beerdb"));
builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddControllers().AddOData(opt => opt.Select().Count().Filter().OrderBy());
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://app:4200", "http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<BeerServiceDbContext>();
    PrepData.AddData(context);
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.Run();
