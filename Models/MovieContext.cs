using Microsoft.EntityFrameworkCore;

namespace Movies_Api.Models
{
	public class MovieContext : DbContext
	{
		public MovieContext(DbContextOptions<MovieContext> options) : base(options)
		{
		}
        public DbSet<Movie> Movies { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<MovieActor> MovieActors { get; set; }

		/* Config fields
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
		*/
	}
}