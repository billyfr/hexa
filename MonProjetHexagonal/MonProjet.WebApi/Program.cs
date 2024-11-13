using MonProjet.Application.Services;
using MonProjet.Core.Interfaces;
using MonProjet.Infrastructure.Data;
using MonProjet.Infrastructure.Repositories;
using MonProjetHexagonal.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");
    var databaseName = builder.Configuration["MongoDbSettings:DatabaseName"];
    return new MongoDbContext(connectionString, databaseName);
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FDESService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
