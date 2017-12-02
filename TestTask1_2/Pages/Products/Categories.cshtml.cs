using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    public class CategoriesModel : PageModel
    {
        private readonly ApplicationContext _db;
        public List<Category> CategoryList { get; set; }
        public CategoriesModel(ApplicationContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Category category = await _db.Categories.FindAsync(id);

            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}