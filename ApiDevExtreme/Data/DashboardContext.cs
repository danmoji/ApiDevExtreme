using Microsoft.EntityFrameworkCore;
using ApiDevExtreme.Models;
namespace ApiDevExtreme.Data;

public class DashboardContext: DbContext
{
    public DashboardContext() { }

    public DashboardContext(DbContextOptions<DashboardContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Flow> Flows { get; set; } = null!;
    public DbSet<Quality> Qualities { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=DashboardDb;");
    }
}

