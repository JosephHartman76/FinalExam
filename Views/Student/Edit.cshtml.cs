using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentExams.DbContext;
using StudentExams.Models;

namespace StudentExams.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly SchoolDbContext _dbContext;

        public EditModel(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Models.Student EditedStudent { get; set; }

        public IActionResult OnGet(int id)
        {
            EditedStudent = _dbContext.Students.Find(id);

            if (EditedStudent == null)
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

            _dbContext.Entry(EditedStudent).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return RedirectToPage("/Student/Index");
        }
    }
}
