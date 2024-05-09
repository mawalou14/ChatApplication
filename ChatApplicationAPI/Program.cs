using ChatApplicationAPI.ChatHubs;
using ChatApplicationAPI.DataAccessLayer;
using ChatApplicationAPI.Mappings;
using ChatApplicationAPI.Repositories.ApplicationUser;
using ChatApplicationAPI.Repositories.Message;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add the Connection to the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ChatAppConnectionString"));
});

builder.Services.AddScoped<IMessageRepository, IMessageImplementation>();
builder.Services.AddScoped<IApplicationUserRepository, IApplicationUserImplementation>();

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfiles));
builder.Services.AddAutoMapper(typeof(MessageMappingProfiles));

//Add the signalR
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowChatApp",
        builder => builder
        .WithOrigins("https://localhost:7035", "http://localhost:5246")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

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

app.UseCors("AllowChatApp");

app.MapHub<ChatHub>("/chathub");

app.Run();
