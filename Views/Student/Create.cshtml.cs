using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentExams.DbContext;
using StudentExams.Models;

namespace StudentExams.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public CreateModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Student NewStudent { get; set; }

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

            _dbContext.Students.Add(NewStudent);
            _dbContext.SaveChanges();

            return RedirectToPage("/Student/Index");
        }
    }
}
