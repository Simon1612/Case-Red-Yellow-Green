var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


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