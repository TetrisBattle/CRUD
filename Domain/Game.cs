namespace Domain;

public class Game
{
	public string Id { get; set; } = Guid.NewGuid().ToString();

	public required string Name { get; set; }

	// public required string Description { get; set; }

	// public required decimal Price { get; set; }
}
