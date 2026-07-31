using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models;
// Gives Program.cs access to ProjectContext.
using WebAPIProject;

namespace WebAPIProject;

// This class represents the database context.
// It connects the application to the database.
public class ProjectContext : DbContext
{
    // Represents the Categories table in the database.
    public DbSet<Category> Categories { get; set; }

    // Receives the database configuration from Program.cs.
    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }
}
