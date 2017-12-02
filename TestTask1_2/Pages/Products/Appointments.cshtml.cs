using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTask1_2.Models;

namespace TestTask1_2.Pages.Products
{
    public class AppointmentsModel : PageModel
    {
        private readonly ApplicationContext _db;
        public List<Appointment> AppointmentList { get; set; }
        public AppointmentsModel(ApplicationContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            AppointmentList = _db.Appointments.ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Appointment appointment = await _db.Appointments.FindAsync(id);

            if (appointment != null)
            {
                _db.Appointments.Remove(appointment);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}