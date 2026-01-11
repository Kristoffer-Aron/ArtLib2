using ArtLib2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IArtRepository, ArtRepository>();

Boolean useDatabase = false;
IArtRepository _repo;

if (useDatabase)
{
    {
        var optionBuilder = new DbContextOptionsBuilder<ArtRepositoryContext>();
        optionBuilder.UseSqlServer(Secret.ConnectionString);
        ArtRepositoryContext _context = new ArtRepositoryContext(optionBuilder.Options);
        _repo = new ArtRepositoryDB(_context);
    }
}
else
{
    _repo = new ArtRepository();
}

builder.Services.AddSingleton<IArtRepository>(_repo);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
