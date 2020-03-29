using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Disease
{
    public class DeleteModel : PageModel
    {
        private readonly IDiseaseData diseaseData;

        public DeleteModel(IDiseaseData diseaseData)
        {
            this.diseaseData = diseaseData;
        }

        public Core.Disease Disease{ get; set; }
        public IActionResult OnGet(int id)
        {
            Disease = diseaseData.GetDiseaseById(id);
            if (Disease == null)
            {
                return RedirectToPage("~/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var temp = diseaseData.GetDiseaseById(id);
            if (temp == null)
            {
                return RedirectToPage("~/NotFound");
            }
            var temp2 = diseaseData.Delete(temp.Id);

            diseaseData.Commit();
            TempData["TempMessage"] = "The disease is extinct!";
            return RedirectToPage("./List");
        }
    }
}