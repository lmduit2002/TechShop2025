using back_end.Application.Helpers;
using back_end.Application.Interfaces;
using back_end.Application.Services;
using back_end.Domain.Interfaces;
using back_end.Infrastructure.Persistence;
using back_end.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. lmduit2002    TechShop2025
// CLOUDINARY_URL=cloudinary://<your_api_key>:<your_api_secret>@dzzhdffjw
// your_api_key: 475744133953825
// your_api_secret: FYGrTmUuPx0RVMRFnBeurSRMp6k

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("TechShop2025"));
});

// BEGIN ADD SCOPE
builder.Services.AddScoped<IProductRepository,ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
// END ADD SCOPE
builder.Services.AddAuthentication();
var app = builder.Build();

// Bind json to class (appsetting.json)
builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  

app.UseAuthorization();

app.MapControllers();

app.Run();
