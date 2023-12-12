using Mountain.Wildcat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

String storeConnectionString = builder.Configuration.GetConnectionString("StoreConnection") ??
    throw new ArgumentNullException("ConnectionString:StoreConnection");   

builder.Services.AddDbContext<StoreContext>(Options =>
    Options.UseSqlServer(storeConnectionString,
    b => b.MigrationsAssembly("Emerald.Tiger.Api"))
    );
    
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(
    options => options.UseSqlite(
        "Data source =../Registrar.sqlite",
        b => b.MigrationsAssembly("Mountain.Wildcat.Api")
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
