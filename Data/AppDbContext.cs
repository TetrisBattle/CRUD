using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Game> Games { get; set; }
}
