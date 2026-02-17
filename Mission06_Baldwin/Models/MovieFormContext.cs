using Microsoft.EntityFrameworkCore;

namespace Mission6Assignment.Models;

public class MovieFormContext : DbContext
{
    public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) // Constructor
    {
    }
    
    public DbSet<Movie>  Movies {get; set;} // allows the database to be viewed and changed
}