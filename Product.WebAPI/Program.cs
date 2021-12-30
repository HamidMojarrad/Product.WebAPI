using Productstore.Core;
using Product.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ProductstoreDbConfig>(
    builder.Configuration.GetSection("ProductStoreDatabase"));
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddSingleton<IDbClient, DbClient>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
