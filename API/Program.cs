using ContosoPizza.Data;
using ContosoPizza.Business;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddSingleton<IUserService, UserService>();


// Obteniendo la cadena de conexión desde appsettings.json
// var connectionString = builder.Configuration.GetConnectionString("PizzaDB");

// builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider => 
//     new PizzaSqlRepository(connectionString));


builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment()) //DISABLE DUE TO CONTAINERING APP
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
