var builder = WebApplication.CreateBuilder(args);

// Add services to the container here, before build()
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// configure the HTTP request pipeline, after build()
app.MapCarter();

app.Run();
