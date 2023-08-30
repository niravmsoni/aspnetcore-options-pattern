using OptionsPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<WeatherOptions>().BindConfiguration(nameof(WeatherOptions))
    .ValidateDataAnnotations()
    .ValidateOnStart();
//.Validate(options =>
// {
//     if (options.State != "Kerala") return false;
//     return true;
// });

//var weatherOptions = builder.Configuration.GetSection(nameof(WeatherOptions)).Get<WeatherOptions>();

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

app.Run();
