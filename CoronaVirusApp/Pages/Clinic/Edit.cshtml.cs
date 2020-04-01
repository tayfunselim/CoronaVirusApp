using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Clinic
{
    public class EditModel : PageModel
    {
        private readonly IClinicData clinicData;

        [BindProperty]        

        public Core.Clinic Clinic { get; set; }
        public EditModel(IClinicData clinicData)
        {
            this.clinicData = clinicData;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Clinic = clinicData.GetClinicById(id.Value);
                if (Clinic == null)
                {
                    return RedirectToPage("~/NotFound");
                }
            }
            else
            {
                Clinic = new Core.Clinic();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Clinic.Id == 0)
                {
                    Clinic = clinicData.Create(Clinic);
                    TempData["TempMessage"] = "New clinic is created!";
                }
                else
                {
                    Clinic = clinicData.Update(Clinic);
                    TempData["TempMessage"] = "Clinic details are updated";
                }

                clinicData.Commit();
                return RedirectToPage("./List");
            }
            return Page();
        }
    }
}