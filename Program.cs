using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<AkunContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<KantorContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<LayarContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<PenggunaContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<PeranContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<PeranLayarContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        }
    );
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
