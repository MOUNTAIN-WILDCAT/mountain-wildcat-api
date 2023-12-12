using Mountain.Wildcat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Emerald.Tiger.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

string authority = builder.Configuration["Auth0:Authority"]??
    throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Audience"] ??
    throw new ArgumentNullException("Auth0:Authority");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.AddPolicy("delete:catalog", policy =>
    policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    optionsDefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    options.Authority = authority;
    options.Audience = audience;

});
builder.Services.AddDbContext<StoreContext>(
    options => options.UseSqlite(
        "Data source =../Registrar.sqlite",
        b => b.MigrationsAssembly("Mountain.Wildcat.Api")
    )
);
builder.Services.AddCors(options
{
    options.AddDefaultPolicy(builder
{
        builder.WithOrgins("http:localhost.3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
});
});



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

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
