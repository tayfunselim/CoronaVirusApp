using System.Collections.Generic;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Appointment
{
    public class ListModel : PageModel
    {
        private readonly IAppointmentData appointmentData;

        public ListModel(IAppointmentData appointmentData)
        {
            this.appointmentData = appointmentData;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Core.Appointment> Appointments { get; set; }

        public void OnGet()
        {
            Appointments = appointmentData.GetAppointments();
        }
    }
}