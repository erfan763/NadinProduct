using Application;
using InferStructure.Context;
using InferStructure.Extensions;
using InferStructure.Extentions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigurationApplication();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.ConfigureJWTServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
dataContext?.Database.EnsureCreated();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
        options.RoutePrefix = "swagger";
    });
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.Run();