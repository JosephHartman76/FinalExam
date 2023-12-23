using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentExams.DbContext;
using StudentExams.Models;

namespace StudentExams.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public IndexModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentExams.Models.Teacher> Teachers { get; set; }

        public void OnGet()
        {
            Teachers = _dbContext.Teachers.ToList();
        }
    }
}
