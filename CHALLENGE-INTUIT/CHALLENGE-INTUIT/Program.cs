using CHALLENGE_INTUIT;
using CHALLENGE_INTUIT.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Creamos la conexion a la base de datos
builder.Services.AddDbContext<MyContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Registramos el servicio
builder.Services.AddScoped<ClientService>();


// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();//fuerza que corran los http en https para reforzar la seguridad 

app.UseAuthorization();//habilidate el middelware de autorizacion

app.MapControllers();//mapea los controladores ,hace que los endpoint respondan a las rutas http

app.Run();//corre la aplicacion, inicia el servidor y hace que la aplicacoin escuche el puerto configurado
