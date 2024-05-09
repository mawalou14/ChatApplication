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

app.MapHub<ChatHub>("/chathub");

app.Run();
