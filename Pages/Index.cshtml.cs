using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentExams.DbContext;
using StudentExams.Models;

namespace StudentExams.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SchoolDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, SchoolDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public Exam Exam { get; set; }

        public bool IsSuccess { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Exam> Exams { get; set; }

        public void OnGet()
        {
            Teachers = _dbContext.Teachers.ToList();
            Students = _dbContext.Students.ToList();
            Exams = _dbContext.Exams.Include(e => e.Student).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add new teacher
            if (Teacher != null)
            {
                _dbContext.Teachers.Add(Teacher);
            }

            // Add new student
            if (Student != null)
            {
                _dbContext.Students.Add(Student);
            }

            // Add new exam
            if (Exam != null)
            {
                _dbContext.Exams.Add(Exam);
            }

            _dbContext.SaveChanges();

            // Set TempData for success message
            TempData["IsSuccess"] = true;

            return RedirectToPage("/Index");
        }
    }
}
