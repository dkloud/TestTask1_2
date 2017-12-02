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
    public class ChangeAppointmentModel : PageModel
    {
        private readonly ApplicationContext _db;
        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }
        [BindProperty(SupportsGet =true)]
        public int? AppointmentId { get; set; }
        public List<Appointment> AppointmentListToAdd { get; set; }
        public List<Appointment> AppointmentListToDelete { get; set; }
        public Category CategoryToShow { get; set; }
        public ChangeAppointmentModel(ApplicationContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            AppointmentListToAdd = _db.Appointments.Include(a => a.Category).Where(app => app.CategoryId == null).ToList();
            AppointmentListToDelete = _db.Appointments.Include(a => a.Category).Where(app => app.CategoryId == CategoryId).ToList();
            CategoryToShow = _db.Categories.Find(CategoryId);
        }

        //Adding Appointment to Category
        public async Task<IActionResult> OnPostAddAsync()
        {
            if (CategoryId == null)
            {
                return NotFound();
            }

            Category category = _db.Categories.Include(c => c.Appointments).Where(c => c.Id == CategoryId).FirstOrDefault();
            if (category == null)
                return RedirectToPage("/Error");

            //Appointment appointment = AppointmentListToAdd.Where(a => a.Id == AppointmentId).FirstOrDefault();
            Appointment appointment = _db.Appointments.Where(a => a.Id == AppointmentId && a.CategoryId == null).FirstOrDefault();
            if (appointment == null)
                return RedirectToPage("/Error");

            if (ModelState.IsValid)
            {
                category.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return RedirectToPage("ChangeAppointment", new { CategoryId = CategoryId });
            }
            return RedirectToPage();
        }
        
        //Removing Appointment from Category
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            if (CategoryId == null)
            {
                return NotFound();
            }

            Category category = _db.Categories.Include(c => c.Appointments).Where(c => c.Id == CategoryId).FirstOrDefault();
            if (category == null)
                return RedirectToPage("/Error");

            Appointment appointment = _db.Appointments.Where(a => a.Id == AppointmentId && a.CategoryId == CategoryId).FirstOrDefault();
            if (appointment == null)
                return RedirectToPage("/Error");

            if (ModelState.IsValid)
            {
                category.Appointments.Remove(appointment);
                await _db.SaveChangesAsync();
                return RedirectToPage("ChangeAppointment", new { CategoryId = CategoryId });
            }
            return RedirectToPage();
        }
    }
}