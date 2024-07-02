var builder = WebApplication.CreateBuilder(args);

// Add services to the container here, before build()

var app = builder.Build();

// configure the HTTP request pipeline, after build()

app.Run();
