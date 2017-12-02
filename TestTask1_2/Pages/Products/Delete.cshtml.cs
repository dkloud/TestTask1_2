using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    //Just for development testing
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext _db;
        public List<Appointment> Apps { get; set; }
        public List<Category> Cats { get; set; }
        public DeleteModel(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            Apps = _db.Appointments.ToList();
            Cats = _db.Categories.ToList();
            foreach (var app in Apps)
            {
                _db.Appointments.Remove(app);
                _db.SaveChanges();
            }
            foreach (var cat in Cats)
            {
                _db.Categories.Remove(cat);
                _db.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}