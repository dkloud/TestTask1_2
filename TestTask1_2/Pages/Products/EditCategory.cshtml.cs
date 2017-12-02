using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    public class EditCategoryModel : PageModel
    {
        private readonly ApplicationContext _db;
        [BindProperty]
        public Category Category { get; set; }
        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }
        public EditCategoryModel(ApplicationContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Id == null)
            {
                return NotFound();
            }

            Category EditedCategory = await _db.Categories.FindAsync(Id);
            if (EditedCategory == null)
                return NotFound();
            EditedCategory.Name = Category.Name;
            EditedCategory.Description = Category.Description;

            await _db.SaveChangesAsync();
            return RedirectToPage("Categories");
        }
    }
}