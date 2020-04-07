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
                return RedirectToPage("~/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = appointmentData.GetAppointmentById(id);
            if (temp == null)
            {
                return RedirectToPage("~/NotFound");
            }
            var temp2 = appointmentData.Delete(temp.Id);

            appointmentData.Commit();
            TempData["TempMessage"] = "The appointment is deleted!";
            return RedirectToPage("./List");
        }
    }
}