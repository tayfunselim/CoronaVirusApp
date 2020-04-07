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
        private readonly IDoctorData doctorData;
        private readonly IHtmlHelper htmlHelper;
        

        [BindProperty]
        public Core.Patient Patient { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }

        public EditModel(IPatientData patientData, IDoctorData doctorData, IHtmlHelper htmlHelper)
        {
            this.patientData = patientData;
            this.doctorData = doctorData;
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
            var doctors = doctorData.GetDoctors().ToList().Select(d => new { Id = d.Id, Display = $"{d.FirstName} {d.LastName}"});
            Doctors = new SelectList(doctors, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();            
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var doctor = doctorData.GetDoctorById(Patient.DoctorId);
                Patient.Doctor = doctor;
                if (Patient.Id == 0)
                {
                    Patient = patientData.Create(Patient);
                    TempData["TempMessage"] = "New patient is created!";
                }
                else
                {
                    Patient = patientData.Update(Patient);
                    TempData["TempMessage"] = "Data for patient is updated!";
                }

                patientData.Commit();
                return RedirectToPage("./List");
            }

            var doctors = doctorData.GetDoctors().ToList().Select(d => new { Id = d.Id, Display = $"{d.FirstName} {d.LastName}" });
            Doctors = new SelectList(doctors, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();            
            return Page();
        }
    }
}