var builder = WebApplication.CreateBuilder(args);

// Add services to the container here, before build()
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// configure the HTTP request pipeline, after build()
app.MapCarter();

app.Run();
