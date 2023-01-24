using Todo.Core;
using AutoMapper;
using System.Text;
using Service.DTO;
using Service.services; 
using Service.interfaces;
using Todo.Infra.Context;
using Todo.API.Model.User;
using Todo.Domain.Entities;
using Todo.Infra.Interfaces;
using Todo.Infra.Repositories;
using Microsoft.OpenApi.Models;
using Todo.API.Model.Assignment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ScottBrady91.AspNetCore.Identity; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Todo.API.Model.AssignmentList;

var builder = WebApplication.CreateBuilder(args);


#region Configuração do JWT (AddAuthentication e AddJwtBearer)
builder.Services// trecho de codigo do ivan
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x => //como exatamente isso funciona?
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidAudience = builder.Configuration["AppSettings:Audience"], 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
        };
    });

// builder.Services.AddAuthentication(x =>
// {
//     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
// })
//     .AddJwtBearer(
//         x =>
//         {
//             x.RequireHttpsMetadata = false;
//             x.SaveToken = true;
//             x.TokenValidationParameters = new TokenValidationParameters
//             {
//                 ValidateIssuerSigningKey = true,
//                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
//                 ValidateIssuer = false,
//                 ValidateAudience = false
//             };
//         })
//     ;
#endregion



#region Configuração do AutoMapper
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>().ReverseMap();
    cfg.CreateMap<UserDTO, CreateUserModel>().ReverseMap();
    cfg.CreateMap<UserDTO, UpdateUserModel>().ReverseMap();
    
    cfg.CreateMap<Assignment, AssignmentDTO>().ReverseMap();
    cfg.CreateMap<AssignmentDTO, CreateAssignmentModel>().ReverseMap();
    cfg.CreateMap<AssignmentDTO, UpdateAssignmentModel>().ReverseMap(); 
    
    cfg.CreateMap<AssignmentList, AssignmentListDTO>().ReverseMap();
    cfg.CreateMap<AssignmentListDTO, CreateAssignmentListModel>().ReverseMap(); 
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
#endregion



#region Injeção de Dependencias (DI)
builder.Services.AddSingleton(d => builder.Configuration); 
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>(); //pesquisar sobre isso

builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

builder.Services.AddScoped<IAssignmentListRepository, AssignmentListRepository>();
builder.Services.AddScoped<IAssignmentListService, AssignmentListService>();

builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IPasswordHasher<User>, Argon2PasswordHasher<User>>();

builder.Services.AddHttpContextAccessor(); // substitui builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>(); 
#endregion



#region Database
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<TodoDbContext>(
    options => options.UseMySql(
        mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)
    )
);
#endregion



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { 
        Title = "To Do API",
        Version = "v1",
        Description = "Desafio ToDo do NDS(Núcleo de Desenvolvimento de Sistemas) do IFCE Campos Maracanau.",
        Contact = new OpenApiContact
        {
            Name = "Mac Myller",
            Email = "myllersilva1310@gmail.com",
            Url = new Uri("https://github.com/myller-silva")
        }
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor utilize o Bearer <Token>",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer" }
            }, new List<string>() }
    });
});

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Console.WriteLine(builder.Configuration["AppSettings:Issuer"]);
// Console.WriteLine(builder.Configuration["AppSettings:Audience"]);
 
app.UseHttpsRedirection();

app.UseAuthentication(); //vou precisar?

app.UseAuthorization();

app.MapControllers();

app.Run(); // descomentar
