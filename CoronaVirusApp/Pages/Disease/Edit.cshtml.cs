using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoronaVirusApp.Pages.Disease
{
    public class EditModel : PageModel
    {
        private readonly IDiseaseData diseaseData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Disease Disease{ get; set; }
        
        public IEnumerable<SelectListItem> DiseaseType { get; set; }

        public EditModel(IDiseaseData diseaseData, IHtmlHelper htmlHelper)
        {
            this.diseaseData = diseaseData;
            this.htmlHelper = htmlHelper;
            //this.diseaseTypes = diseaseTypes;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Disease = diseaseData.GetDiseaseById(id.Value);
                if (Disease == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Disease = new Core.Disease();
            }


            DiseaseType = htmlHelper.GetEnumSelectList<DiseaseType>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Disease.Id == 0)
                {
                    Disease = diseaseData.Create(Disease);
                    TempData["TempMessage"] = "New Disease is created!";
                }
                else
                {
                    Disease = diseaseData.Update(Disease);
                    TempData["TempMessage"] = "Disease information is updated!";
                }
                diseaseData.Commit();
                return RedirectToPage("./List");
            }
            DiseaseType = htmlHelper.GetEnumSelectList<DiseaseType>();
            return Page();
        }
    }
}