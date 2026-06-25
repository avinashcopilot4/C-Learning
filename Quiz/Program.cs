using BusinessCore;
using BusinessCore.Interfaces;
using Entity.Data;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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