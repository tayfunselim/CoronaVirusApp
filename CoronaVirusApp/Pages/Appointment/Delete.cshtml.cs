using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Appointment
{
    public class DeleteModel : PageModel
    {
        private readonly IAppointmentData appointmentData;

        public DeleteModel(IAppointmentData appointmentData)
        {
            this.appointmentData = appointmentData;
        }

        public Core.Appointment Appointment { get; set; }
        public IActionResult OnGet(int id)
        {
            Appointment = appointmentData.GetAppointmentById(id);
            if (Appointment == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = appointmentData.Delete(id);
            if (temp == null)
            {
                return RedirectToPage("./NotFound");
            }

            appointmentData.Commit();
            TempData["TempMessage"] = "The customer is deleted!";
            return RedirectToPage("./List");
        }
    }
}