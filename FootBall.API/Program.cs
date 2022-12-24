
using FootBall.API.Context;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = "ბაზის გზა";

builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(connection));

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseEndpoints(end => end.MapControllers());

app.Run();
