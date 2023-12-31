using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyHomeWebSite.Methods;
using MyHomeWebSite.Models;

var builder = WebApplication.CreateBuilder(args);

//DI dbcontext
builder.Services.AddDbContext<MyDBContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));

builder.Services.AddScoped<LoginMethod>();
builder.Services.AddScoped<UserMethod>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.UseCors();
app.Run();
