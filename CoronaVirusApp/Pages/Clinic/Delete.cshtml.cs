using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Clinic
{
    public class DeleteModel : PageModel
    {
        private readonly IClinicData clinicData;

        public DeleteModel(IClinicData clinicData)
        {
            this.clinicData = clinicData;
        }

        public Core.Clinic Clinic { get; set; }
        public IActionResult OnGet(int id)
        {
            Clinic = clinicData.GetClinicById(id);
            if (Clinic == null)
            {
                return RedirectToPage("~/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = clinicData.Delete(id);
            if (temp == null)
            {
                return RedirectToPage("./NotFound");
            }

            clinicData.Commit();
            TempData["TempMessage"] = "The clinic is deleted!";
            return RedirectToPage("./List");
        }
    }
}