using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentExams.DbContext;
using StudentExams.Models;

namespace StudentExams.Pages.Exam
{
    public class CreateModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        [BindProperty]
        public Exam Exam { get; set; }

        public CreateModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

            _dbContext.Exams.Add(Exam);
            _dbContext.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}