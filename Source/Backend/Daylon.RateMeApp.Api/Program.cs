using Daylon.RateMeApp.Application;
using Daylon.RateMeApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add Dependency Injection
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

//==|=====>
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//     ╱|、
//    (-ˎ- >  
//    |、˜〵          
//    じしˍ,)ノ D A Y L O N