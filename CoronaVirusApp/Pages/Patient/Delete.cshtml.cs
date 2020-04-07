using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Patient
{
    public class DeleteModel : PageModel
    {
        private readonly IPatientData patientData;

        public DeleteModel(IPatientData patientData)
        {
            this.patientData = patientData;
        }

        public Core.Patient Patient { get; set; }
        public IActionResult OnGet(int id)
        {
            Patient = patientData.GetPatientById(id);
            if (Patient == null)
            {
                return RedirectToPage("~/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = patientData.GetPatientById(id);
            if (temp == null)
            {
                return RedirectToPage("~/NotFound");
            }
            patientData.Commit();            
            TempData["TempMessage"] = "The patient is deleted";
            return RedirectToPage("./List");
        }
    }
}