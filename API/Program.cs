
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    var connstr = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    //opt.UseSqlite("Data Source=datingapp.db");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
