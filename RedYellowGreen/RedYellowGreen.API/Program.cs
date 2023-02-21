var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<RedYellowGreen.API.Equipment.IRepository, RedYellowGreen.API.Equipment.Repository>();
builder.Services.AddTransient<RedYellowGreen.API.Order.IRepository, RedYellowGreen.API.Order.Repository>();
builder.Services.AddTransient<RedYellowGreen.API.Schedule.IRepository, RedYellowGreen.API.Schedule.Repository>();
builder.Services.AddTransient<RedYellowGreen.API.Equipment.IService, RedYellowGreen.API.Equipment.Service>();
builder.Services.AddTransient<RedYellowGreen.API.Order.IService, RedYellowGreen.API.Order.Service>();
builder.Services.AddTransient<RedYellowGreen.API.Schedule.IService, RedYellowGreen.API.Schedule.Service>();

// Let's ignore logging for this exercise.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization(); - Let's ignore Authorization too.
app.MapControllers();

app.Run();