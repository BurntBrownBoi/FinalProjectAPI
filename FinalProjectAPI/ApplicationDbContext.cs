using Microsoft.EntityFrameworkCore;
using FinalProjectAPI.Models; // Replace "YourNamespace" with the namespace you used in your model classes


public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	public DbSet<TeamMember> TeamMembers { get; set; }
	public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
	public DbSet<FavoriteCar> FavoriteCars { get; set; }
	public DbSet<FavoriteFood> FavoriteFoods { get; set; }
}
