using ContosoPizza.Business;
using ContosoPizza.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IPizzaService, PizzaService>();
// builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>(); 

var connectionString = builder.Configuration.GetConnectionString("PizzaDB");

builder.Services.AddScoped<IPizzaRepository, PizzaSQLRepository>(serviceProvider =>
new PizzaSQLRepository(connectionString));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
