using System.Collections.Generic;
using System.Linq;
using CoronaVirusApp.Core;
using CoronaVirusApp.Core.Enum;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoronaVirusApp.Pages.Patient
{
    public class EditModel : PageModel
    {
        private readonly IPatientData patientData;
        private readonly IAppointmentData appointmentData;        
        private readonly IHtmlHelper htmlHelper;
        

        [BindProperty]
        public Core.Patient Patient { get; set; }

        
        public IEnumerable<SelectListItem> Appointments { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }
        public IEnumerable<SelectListItem> MedicalHistory { get; set; }


        public EditModel(IPatientData patientData, IAppointmentData appointmentData, IHtmlHelper htmlHelper)
        {
            this.patientData = patientData;
            this.appointmentData = appointmentData;            
            this.htmlHelper = htmlHelper;
            
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Patient = patientData.GetPatientById(id.Value);
                if (Patient == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Patient = new Core.Patient();
            }                        
            
            var appointments = appointmentData.GetAppointments().ToList().Select(a => new {Id = a.Id, Display = "Appointment no: "+ a.Id });
            Appointments = new SelectList(appointments, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            MedicalHistory = htmlHelper.GetEnumSelectList<MedicalHistory>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var appointment = appointmentData.GetAppointmentById(Patient.AppointmentId);
                Patient.Appointment = appointment;                
                if (Patient.Id == 0)
                {
                    Patient = patientData.Create(Patient);
                    TempData["TempMessage"] = "New patient is created!";
                }
                else
                {
                    Patient = patientData.Update(Patient);
                    TempData["TempMessage"] = "Data for customer is updated!";
                }

                patientData.Commit();
                return RedirectToPage("./List");
            }

            var appointments = appointmentData.GetAppointments().ToList().Select(a => new { Id = a.Id, Display = "Appointment no: " + a.Id });
            Appointments = new SelectList(appointments, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            MedicalHistory = htmlHelper.GetEnumSelectList<MedicalHistory>();
            return Page();
        }
    }
}