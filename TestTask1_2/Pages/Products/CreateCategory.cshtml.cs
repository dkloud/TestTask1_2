using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    public class CreateCategoryModel : PageModel
    {
        private readonly ApplicationContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateCategoryModel(ApplicationContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //Category.Appointments = new List<Appointment>();
                _db.Categories.Add(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}