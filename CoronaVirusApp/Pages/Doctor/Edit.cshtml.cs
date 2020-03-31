using CoronaVirusApp.Core.Enum;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace CoronaVirusApp.Pages.Doctor
{
    public class EditModel : PageModel
    {
        private readonly IDoctorData doctorData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Doctor Doctor { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }

        public EditModel(IDoctorData doctorData, IHtmlHelper htmlHelper)
        {
            this.doctorData = doctorData;
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
            Gender = htmlHelper.GetEnumSelectList<Gender>();
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
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            return Page();
        }
    }
}