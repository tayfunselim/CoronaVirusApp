using CoronaVirusApp.Core.Enum;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoronaVirusApp.Pages.Doctor
{
    public class EditModel : PageModel
    {
        private readonly IDoctorData doctorData;
        private readonly IClinicData clinicData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Doctor Doctor { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }
        public IEnumerable<SelectListItem> Clinics { get; set; }

        public EditModel(IDoctorData doctorData, IClinicData clinicData, IHtmlHelper htmlHelper)
        {
            this.doctorData = doctorData;
            this.clinicData = clinicData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Doctor = doctorData.GetDoctorById(id.Value);
                if (Doctor == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Doctor = new Core.Doctor();
            }
            var clinics = clinicData.GetClinics().ToList().Select(p => new { Id = p.Id, Display = p.Name });
            Clinics = new SelectList(clinics, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var clinic = clinicData.GetClinicById(Doctor.ClinicId);
                Doctor.Clinic = clinic;
                if (Doctor.Id == 0)
                {
                    Doctor = doctorData.Create(Doctor);
                    TempData["TempMessage"] = "New doctor is hired!";
                }
                else
                {
                    Doctor = doctorData.Update(Doctor);
                    TempData["TempMessage"] = "Doctor information is updated!";
                }

                doctorData.Commit();
                return RedirectToPage("./List");
            }
            var clinics = clinicData.GetClinics().ToList().Select(p => new { Id = p.Id, Display = p.Name });
            Clinics = new SelectList(clinics, "Id", "Display");
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            return Page();
        }
    }
}