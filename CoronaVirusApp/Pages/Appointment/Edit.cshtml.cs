using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoronaVirusApp.Pages.Appointment
{
    public class EditModel : PageModel
    {
        private readonly IAppointmentData appointmentData;
        private readonly IClinicData clinicData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Appointment Appointment { get; set; }
        public IEnumerable<SelectListItem> Clinics { get; set; }
        public IEnumerable<SelectListItem> Symptom { get; set; }

        public EditModel(IAppointmentData appointmentData, IClinicData clinicData, IHtmlHelper htmlHelper)
        {
            this.appointmentData = appointmentData;
            this.clinicData = clinicData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Appointment = appointmentData.GetAppointmentById(id.Value);
                if (Appointment == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Appointment = new Core.Appointment();
            }

            var clinics = clinicData.GetClinics().ToList().Select(c => new { Id = c.Id, Display = c.Name });
            Clinics = new SelectList(clinics, "Id", "Display");
            Symptom = htmlHelper.GetEnumSelectList<Symptom>();
            return Page();
        }

        public IActionResult OnPost()
        {
            
            if (ModelState.IsValid)
            {
                var clinic = clinicData.GetClinicById(Appointment.ClinicId);
                Appointment.Clinic = clinic;
                if (Appointment.Id == 0)
                {
                    Appointment = appointmentData.Create(Appointment);
                    TempData["TempMessage"] = "New appointment created!";
                }
                else
                {
                    Appointment = appointmentData.Update(Appointment);
                    TempData["TempMessage"] = "Appointment is updated!";
                }
                appointmentData.Commit();
                return RedirectToPage("./List");
            }
            var clinics = clinicData.GetClinics().ToList().Select(c => new { ID = c.Id, Display = $"{c.Name}" });
            Clinics = new SelectList(clinics, "Id", "Display");
            Symptom = htmlHelper.GetEnumSelectList<Symptom>();
            return Page();
        }
    }
}