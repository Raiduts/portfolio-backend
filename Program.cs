using Microsoft.EntityFrameworkCore;
using portfolio_api.Services;
using portfolio_api.Data;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<CommentService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// middleware
app.UseHttpsRedirection();
app.UseCors("AllowNextJS");
app.UseAuthorization();

app.MapControllers();

app.Run();