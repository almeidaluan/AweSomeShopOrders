using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddOcelot();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

if(environment.EnvironmentName == "Development"){
    
    configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").AddJsonFile("ocelot.json");
    Console.WriteLine(builder.Configuration["variavelAmbiente"]);
}else{
    
    configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddJsonFile("ocelot.json");
    Console.WriteLine(builder.Configuration["variavelAmbiente"]);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseOcelot();

app.MapControllers();

app.Run();
