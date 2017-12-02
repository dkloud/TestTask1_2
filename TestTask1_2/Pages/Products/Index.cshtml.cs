using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTask1_2.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.Include(c => c.Appointments).ToList();
        }
        public void OnPostAll()
        {
            CategoryList = _db.Categories.Include(c => c.Appointments).ToList();
        }
        public void OnPostActual()
        {
            CategoryList = _db.Categories.Include(c => c.Appointments).ToList();
            foreach (Category category in CategoryList)
            {
                foreach (Appointment appointment in category.Appointments.ToList())
                {
                    if (appointment.DateEndOfActuality.CompareTo(DateTime.Now) < 0 || appointment.DateEndOfActuality.CompareTo(DateTime.Now) == 0)
                    {
                        category.Appointments.Remove(appointment);
                    }
                }
            }
        }
    }
}