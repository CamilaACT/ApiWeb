var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()  // Permite todas las peticiones de cualquier origen
                   .AllowAnyMethod()  // Permite todos los métodos (GET, POST, PUT, DELETE, etc.)
                   .AllowAnyHeader(); // Permite todos los encabezados
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Coloca UseCors justo aquí, antes de Authorization
app.UseCors("AllowAllOrigins"); // Aplica la política de CORS

app.UseAuthorization();

app.MapControllers();

app.Run();