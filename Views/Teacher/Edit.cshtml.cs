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
    public class EditModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public EditModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Teacher EditedTeacher { get; set; }

        public IActionResult OnGet(int id)
        {
            EditedTeacher = _dbContext.Teachers.Find(id);

            if (EditedTeacher == null)
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

            _dbContext.Entry(EditedTeacher).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToPage("/Teacher/Index");
        }
    }
}
