using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Appointment
{
    public class DetailsModel : PageModel
    {
        private readonly IAppointmentData appointmentData;

        public Core.Appointment Appointment { get; set; }
        public DetailsModel(IAppointmentData appointmentData)
        {
            this.appointmentData = appointmentData;
        }

        public IActionResult OnGet(int id)
        {
            Appointment = appointmentData.GetAppointmentById(id);
            if (Appointment == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}