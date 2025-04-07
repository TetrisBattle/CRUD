using Domain;

namespace Data.Seed;

public static class Seed
{
	public static async Task SeedData(AppDbContext context)
	{
		if (!context.Games.Any())
		{
			var gameSeed = GameSeed.GetSeed();
			context.Games.AddRange(gameSeed);
			await context.SaveChangesAsync();
		}
	}
}
