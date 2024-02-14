using ContosoPizza.Data;
using ContosoPizza.Business;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var connectionString = builder.Configuration.GetConnectionString("ServerDB");

// builder.Services.AddScoped<IUserRepository, UserSqlRepository>(serviceProvider => 
//     new UserSqlRepository(connectionString));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));
  builder.Services.AddScoped<IUserRepository, UserEFRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
