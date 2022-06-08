using webapi;
using webapidotnet.Middlewares;
using webapidotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyectar dependencia
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();
//inyectar dependencia directamente desde la clase sin crear un interfaz
builder.Services.AddScoped(p => new HelloWorldService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// crear una pantalla de bienvenida
//app.UseWelcomePage();

// middleware personalizado
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
