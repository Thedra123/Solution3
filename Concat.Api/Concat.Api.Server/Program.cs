using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Concat.API.Model;
using Concat.API.Services;
using Concat.API.Infraction.Conctret;
using Concat.API.Infraction.Abstruct;
using Concat.Api.Server.Mapper;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization();

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
builder.Services.AddAutoMapper(typeof(HospitalWorkMapper).Assembly);
builder.Services.AddAutoMapper(typeof(GotTicketMapper).Assembly);

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


app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
