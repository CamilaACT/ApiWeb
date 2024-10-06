using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiProyecto.Custom;




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

//AUTENTIFICACION TOKENS
builder.Services.AddSingleton<Utilidades>();

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters=new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        //Se puede especificar quien puede accder colocando dominios pero no es necesario
        ValidateIssuer =false,
        ValidateAudience =false,
        ValidateLifetime =true, //tiempo de vida de token
        ClockSkew=TimeSpan.Zero, 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))

    };
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();