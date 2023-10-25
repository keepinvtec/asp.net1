using Microsoft.EntityFrameworkCore;
using ServiceStationWeb;
using ServiceStationWeb.Entity;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarServiceContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<ITicketService, TicketService>();

var app = builder.Build();

app.UseMiddleware<TicketMiddleware>();


app.UseWelcomePage();
app.Run();
