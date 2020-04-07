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
        private readonly IHtmlHelper htmlHelper;
        private readonly IPatientData patientData;

        [BindProperty]
        public Core.Appointment Appointment { get; set; }        
        public IEnumerable<SelectListItem> Patients { get; set; }
        public IEnumerable<SelectListItem> Symptom { get; set; }

        public EditModel(IAppointmentData appointmentData, IHtmlHelper htmlHelper, IPatientData patientData)
        {
            this.appointmentData = appointmentData;            
            this.htmlHelper = htmlHelper;
            this.patientData = patientData;
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
                        
            var patients = patientData.GetPatients().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}"});
            Patients = new SelectList(patients, "Id", "Display");
            Symptom = htmlHelper.GetEnumSelectList<Symptom>();
            return Page();
        }

        public IActionResult OnPost()
        {
            
            if (ModelState.IsValid)
            {
                var patient = patientData.GetPatientById(Appointment.PatientId);
                Appointment.Patient = patient;
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
            var patients = patientData.GetPatients().ToList().Select(p => new { Id = p.Id, Display = $"{p.FirstName} {p.LastName}" });
            Patients = new SelectList(patients, "Id", "Display");
            Symptom = htmlHelper.GetEnumSelectList<Symptom>();
            return Page();
        }
    }
}