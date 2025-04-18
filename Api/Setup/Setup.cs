using Api.Middleware;
using Application.Core;
using Application.Games;
using Data;
using Data.Seed;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Api.Setup;

public static class Setup
{
	public static void SetupServices(WebApplicationBuilder builder)
	{
		builder.Services.AddOpenApi();

		builder.Services.AddControllers();

		builder.Services.AddDbContext<AppDbContext>(opt =>
		{
			opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
		});

		builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
			policy.AllowAnyHeader()
				 .AllowAnyMethod()
				 .WithOrigins("http://localhost:3000")
		));

		builder.Services.AddTransient<ExceptionMiddleware>();
		builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
		builder.Services.AddValidatorsFromAssemblyContaining<GameValidator>();
		builder.Services.AddScoped<GameService>();
		builder.Services.AddHostedService<PingService>();
	}

	public static void SetupApp(WebApplication app)
	{
		app.UseMiddleware<ExceptionMiddleware>();
		app.UseHttpsRedirection();
		app.UseCors("CorsPolicy");

		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
			app.MapScalarApiReference(options =>
			{
				options.WithTitle("PartPicker");
			});
		}

		app.MapControllers();
	}

	public static async Task SetupDatabase(IServiceProvider services)
	{

		using var scope = services.CreateScope();
		var serviceProvider = scope.ServiceProvider;
		var context = serviceProvider.GetRequiredService<AppDbContext>();

		try
		{
			await context.Database.MigrateAsync();
			await Seed.SeedData(context);
		}
		catch (Exception ex)
		{
			var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "An error occurred during database setup.");
			throw;
		}
	}
}
