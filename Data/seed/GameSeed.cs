using Domain;

namespace Data.Seed;

public static class GameSeed
{
	public static List<Game> GetSeed()
	{
		return
		[
	 		new() {
				Name = "One",
			},
			new() {
				Name = "Two",
			},
			new() {
				Name = "Three",
			},
		];
	}
}
