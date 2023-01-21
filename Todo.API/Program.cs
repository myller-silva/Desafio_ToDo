using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using Service.interfaces;
using Service.services;
using Todo.API.Model;
using Todo.API.Model.User;
using Todo.Domain.Entities;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;
using Todo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");


#region JWT
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
#endregion


#region AutoMapper
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>().ReverseMap();
    cfg.CreateMap<CreateUserModel, UserDTO>().ReverseMap();
    cfg.CreateMap<UpdateUserModel, UserDTO>().ReverseMap();
    cfg.CreateMap<Assignment, AssignmentDTO>().ReverseMap();
    cfg.CreateMap<CreateAssigmentModel, AssignmentDTO>().ReverseMap();
    cfg.CreateMap<AssignmentList, AssignmentListDTO>().ReverseMap();
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
#endregion


#region Dependencias
builder.Services.AddSingleton(d => builder.Configuration);
// builder.Services.AddDbContext<ManagerContext>(
//     options => options.UseSqlServer(builder.Configuration["ConnectionStrings:USER_MANAGER"]), ServiceLifetime.Transient);
builder.Services.AddScoped<IUserService, UserService>(); //pesquisar sobre isso
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
#endregion




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