using Api.Core.Extensions;
using Api.Repository;
using Api.Repository.Core;

const string CONNECT_NAME = "SqlConnection";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbContext>(_ => new DbContext(builder.Configuration.GetConnectionString(CONNECT_NAME)!));
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMigrations(builder.Configuration.GetConnectionString(CONNECT_NAME)!);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.RunMigrate(Migrate.UP, 20230920100000);

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();