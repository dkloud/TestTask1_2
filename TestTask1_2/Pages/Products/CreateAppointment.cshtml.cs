using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    public class CreateAppointmentModel : PageModel
    {
        private readonly ApplicationContext _db;
        [BindProperty]
        public Appointment Appointment { get; set; }
        public CreateAppointmentModel(ApplicationContext db)
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
                Appointment.DateCreate = DateTime.Now;
                _db.Appointments.Add(Appointment);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}