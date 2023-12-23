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
    public class EditModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        [BindProperty]
        public Models.Exam Exam { get; set; }

        public EditModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet(int id)
        {
            Exam = _dbContext.Exams.Find(id);

            if (Exam == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Exams.Update(Exam);
            _dbContext.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
