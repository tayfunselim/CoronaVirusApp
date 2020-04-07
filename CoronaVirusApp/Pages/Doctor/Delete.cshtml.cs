using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Doctor
{
    public class DeleteModel : PageModel
    {
        private readonly IDoctorData doctorData;

        public DeleteModel(IDoctorData doctorData)
        {
            this.doctorData = doctorData;
        }

        public Core.Doctor Doctor{ get; set; }
        public IActionResult OnGet(int id)
        {
            Doctor = doctorData.GetDoctorById(id);
            if (Doctor == null)
            {
                return RedirectToPage("~/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = doctorData.GetDoctorById(id);
            if (temp == null)
            {
                return RedirectToPage("~/NotFound");
            }
            var temp2 = doctorData.Delete(temp.Id);

            doctorData.Commit();
            TempData["TempMessage"] = "The doctor is fired!";
            return RedirectToPage("./List");
        }
    }
}