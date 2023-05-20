using RTD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();

Startup.AddDependencies(services: builder.Services, configuration: builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();