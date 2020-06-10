using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BugTracker.Data;
using System;
using System.Linq;

namespace BugTracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BugTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BugTrackerContext>>()))
            {
                // Look for Reports
                if (context.Report.Any())
                {
                    return; // DB has been seeded
                }

                context.Report.AddRange(
                    new Report
                    {
                        Title = "First Bug",
                        Description = "First Description",
                        Status = false,
                        DateCreated = DateTime.Parse("2020-10-22"),
                        Priority = "Low"
                    },
                    new Report
                    {
                        Title = "Second Bug",
                        Description = "Second Description",
                        Status = true,
                        DateCreated = DateTime.Parse("2020-10-12"),
                        Priority = "High"
                    },
                    new Report
                    {
                        Title = "Third Bug",
                        Description = "Third Description",
                        Status = false,
                        DateCreated = DateTime.Parse("2019-10-22"),
                        Priority = "Medium"
                    },
                    new Report
                    {
                        Title = "Fourth Bug",
                        Description = "Fourth Description",
                        Status = false,
                        DateCreated = DateTime.Parse("0001-10-22"),
                        Priority = "Low"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}