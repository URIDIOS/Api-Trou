var builder = WebApplication.CreateBuilder(args);

// ✅ Agregar CORS al contenedor de servicios
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
	{
		policy
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

// Agregar Swagger y Endpoints (se mantiene después de la configuración de servicios)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la canalización de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// ✅ Activar CORS (antes de MapControllers)
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // <<--- IMPORTANTE
app.UseAuthorization();

app.MapControllers();

app.Run();
