using Microsoft.EntityFrameworkCore;
using WebApi.Base;
using WebApi.Base.IRepositories;
using WebApi.Base.IServices;
using WebApi.Base.Repositories;
using WebApi.Base.Services;
using WebApi.Mappings;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<YCDemoContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")));
builder.Services.AddScoped<DbContext, YCDemoContext>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ControllersProfile>();
});

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

// Unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
