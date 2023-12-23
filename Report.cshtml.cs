using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;  // Add this using directive
using StudentExams.DbContext;  // Add this using directive

namespace StudentExams.Pages
{
    public class ReportModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public ReportModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<LetterGradeDistribution> ReportRows { get; set; }

        public void OnGet()
        {
            ReportRows = _dbContext.GetLetterGradeDistribution();
        }
    }
}
