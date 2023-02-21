var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<RedYellowGreen.API.Equipment.IRepository, RedYellowGreen.API.Equipment.Repository>();
builder.Services.AddTransient<RedYellowGreen.API.Ordering.IRepository, RedYellowGreen.API.Ordering.Repository>();
builder.Services.AddTransient<RedYellowGreen.API.Scheduling.IRepository, RedYellowGreen.API.Scheduling.Repository>();
builder.Services.AddTransient<RedYellowGreen.API.Equipment.IService, RedYellowGreen.API.Equipment.Service>();
builder.Services.AddTransient<RedYellowGreen.API.Ordering.IService, RedYellowGreen.API.Ordering.Service>();
builder.Services.AddTransient<RedYellowGreen.API.Scheduling.IService, RedYellowGreen.API.Scheduling.Service>();

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