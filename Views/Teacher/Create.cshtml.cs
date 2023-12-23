using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentExams.DbContext;
using StudentExams.Models;

namespace StudentExams.Pages.Teacher
{
    public class CreateModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public CreateModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Teacher NewTeacher { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Teachers.Add(NewTeacher);
            _dbContext.SaveChanges();

            return RedirectToPage("/Teacher/Index");
        }
    }
}
