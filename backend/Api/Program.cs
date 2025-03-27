using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
    policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => {
        options.WithTitle("Sale");
    });
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();
