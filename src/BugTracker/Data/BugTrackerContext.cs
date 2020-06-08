using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext (
            DbContextOptions<BugTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<BugTracker.Models.Report> Report {get; set;}
    }
}