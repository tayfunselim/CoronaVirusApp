using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoronaVirusApp.Pages.Doctor
{
    public class EditModel : PageModel
    {
        private readonly IDoctorData doctorData;

        [BindProperty]
        public Core.Doctor Doctor { get; set; }

        public EditModel(IDoctorData doctorData)
        {
            this.doctorData = doctorData;
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

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
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
            return Page();
        }
    }
}