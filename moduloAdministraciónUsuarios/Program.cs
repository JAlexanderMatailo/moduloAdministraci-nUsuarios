using dbPrueba;
using Microsoft.EntityFrameworkCore;
using moduloAdministraciónUsuarios.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsuario, UsuarioService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Conexion a Base de Datos
builder.Services.AddDbContext<pruebaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaConnection"))
);
#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "API",
                      builder =>
                      {
                          builder.WithHeaders("*");
                          builder.WithOrigins("*");
                          builder.WithMethods("*");

                      });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<pruebaContext>();
    context.Database.Migrate();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("API");

app.MapControllers();

app.Run();
