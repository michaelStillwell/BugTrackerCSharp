using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly BugTracker.Data.BugTrackerContext _context;

        public IndexModel(BugTracker.Data.BugTrackerContext context)
        {
            _context = context;
        }

        public IList<Report> Report { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString {get; set;}
        // Requires using Microsoft.AspNetCore.Mvc.Rendering
        public SelectList Status {get; set;}
        [BindProperty(SupportsGet = true)]
        public string ReportStatus {get; set;}

        public async Task OnGetAsync()
        {
            IQueryable<bool> statusQuery = from r in _context.Report orderby r.Status select r.Status;
            var reports = from r in _context.Report select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                reports = reports.Where(s => s.Title.Contains(SearchString));
            }
            
            Status = new SelectList(await statusQuery.Distinct().ToListAsync());
            Report = await reports.ToListAsync();
        }
    }
}
