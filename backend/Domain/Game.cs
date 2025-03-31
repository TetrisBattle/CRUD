using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Game
{
	public string Id { get; set; } = Guid.NewGuid().ToString();

	[StringLength(100)]
	public required string Name { get; set; }

	// public required string Description { get; set; }

	// [Range(0, 9999.99)]
	// public required decimal Price { get; set; }
}
