using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MultiTenantNoteApp.Context.MasterDbContext;
using MultiTenantNoteApp.Context.TenantDbContext;
using MultiTenantNoteApp.Helper;
using MultiTenantNoteApp.Middleware;
using MultiTenantNoteApp.Repositary.AddProjectRepository;
using MultiTenantNoteApp.Repositary.AddTaskRepository;
using MultiTenantNoteApp.Repositary.AddTenantRepository;
using MultiTenantNoteApp.Repositary.ChangeTaskRepo;
using MultiTenantNoteApp.Repositary.GetConnectionStringRepository;
using MultiTenantNoteApp.Repositary.GetProjectRepository;
using MultiTenantNoteApp.Repositary.GettaskRepository;
using MultiTenantNoteApp.Repositary.LoginRepository;
using MultiTenantNoteApp.Service.AddProjectService;
using MultiTenantNoteApp.Service.AddTaskService;
using MultiTenantNoteApp.Service.AddTenantService;
using MultiTenantNoteApp.Service.EditTaskStatusService;
using MultiTenantNoteApp.Service.GetProjectService;
using MultiTenantNoteApp.Service.GetTaskService;
using MultiTenantNoteApp.Service.LoginService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<MasterDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<TenantDbContext>(options =>
{
    options.UseSqlServer("ConnectionString");
});


builder.Services.AddScoped<IAddProjectRepo, AddProjectRepo>();
builder.Services.AddScoped<TentantMiddleware>();
builder.Services.AddScoped<IGetTenantConnectionStringRepo, GetTenantConnectionStringRepo>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<IAddTenantRepo, AddTenantRepo>();
builder.Services.AddScoped<IAddTentantService,AddTenantService>();
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAddProjectService, AddProjectService>();
builder.Services.AddScoped<IGetProjectRepo, GetProjectRepo>();
builder.Services.AddScoped<IGetProjectService, GetProjectService>();
builder.Services.AddScoped<IAddTaskRepo, AddTaskRepo>();
builder.Services.AddScoped<IAddTaskService , AddTaskService>();
builder.Services.AddScoped<IGetTasksRepo, GetTasksRepo>();
builder.Services.AddScoped<IGetTaskService, GetTaskService>();
builder.Services.AddScoped<IEditTaskStatusRepo,EditTaskStatusRepo>();
builder.Services.AddScoped<IEditTaskStatusService, EditTaskStatusService>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(op =>
{
    op.IncludeErrorDetails = true;
    op.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
   
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TentantMiddleware>();   

app.MapControllers(); 

app.Run();
