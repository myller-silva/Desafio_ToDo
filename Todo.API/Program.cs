using Microsoft.EntityFrameworkCore;
using Todo.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<TodoDbContext>(
    options => options.UseMySql(
        mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)
    )
);

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