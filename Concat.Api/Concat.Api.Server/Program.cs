using Microsoft.EntityFrameworkCore;
using Concat.API.Model;
using Concat.API.Services;
using Concat.API.Infraction.Conctret;
using Concat.API.Infraction.Abstruct;
using Concat.Api.Server.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContexts for each database
builder.Services.AddDbContext<GotTicketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GotTicketConnection")));

builder.Services.AddDbContext<HospitalNoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalNoConnection")));

builder.Services.AddDbContext<HospitalWorkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalWorkConnection")));

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection")));

// Add repository services
builder.Services.AddScoped<IUserRepositories, UserServices>();
builder.Services.AddScoped<IHospitalWorkRepositories, HospitalWorkServices>();
builder.Services.AddScoped<IGotTicketRepositories, GotTicketServices>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);
builder.Services.AddAutoMapper(typeof(RegisterMapper).Assembly);
builder.Services.AddAutoMapper(typeof(HospitalNoMapper).Assembly);


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
