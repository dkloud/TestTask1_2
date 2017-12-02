using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    public class EditAppointmentModel : PageModel
    {
        private readonly ApplicationContext _db;
        [BindProperty]
        public Appointment Appointment { get; set; }
        [BindProperty]
        public int? Id { get; set; }
        public EditAppointmentModel(ApplicationContext db)
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

            Appointment EditedAppointment = await _db.Appointments.FindAsync(Id);
            if (EditedAppointment == null)
                return NotFound();
            EditedAppointment.Description = Appointment.Description;
            EditedAppointment.DateEndOfActuality = Appointment.DateEndOfActuality;

            await _db.SaveChangesAsync();
            return RedirectToPage("Appointments");
        }
    }
}