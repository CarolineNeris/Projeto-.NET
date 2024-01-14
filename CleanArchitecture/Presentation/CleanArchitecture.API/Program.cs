using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence;
using CleanArchitecture.Application.Services;
using CleanArchitecture.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenseApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateDataBase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();

static void CreateDataBase(WebApplication app) {
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
