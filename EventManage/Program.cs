using EventManage.Models;
using EventManage.Models.IRepositorry;
using EventManage.Models.Repository;
using EventManage.Models.Services.IServices;
using EventManage.Models.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using EventManage.Controllers;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<EventManageContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=RAYMER;Database=EventManage;Trusted_Connection=True;TrustServerCertificate=True;"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepositoryService<Status>, StatusService>();
builder.Services.AddScoped<IRepositoryService<Client>, ClientService>();
builder.Services.AddScoped<IRepositoryService<Event>, EventsService>();
builder.Services.AddScoped<IRepositoryService<ReservationsFurniture>, ReservationsFurnituresService>();
builder.Services.AddScoped<IRepositoryService<Furniture>, FurnituresService>();
builder.Services.AddScoped<IRepositoryService<Reservation>, ReservationsService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
