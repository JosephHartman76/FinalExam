using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentExams.DbContext;
namespace StudentExams.Pages.Exam
{
    public class IndexModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public IndexModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Models.Exam> Exams { get; set; }

        public void OnGet()
        {
            Exams = _dbContext.Exams.ToList();
        }
    }
}
