using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Disease
{
    public class ListModel : PageModel
    {
        private readonly IDiseaseData diseaseData;

        public ListModel(IDiseaseData diseaseData)
        {
            this.diseaseData = diseaseData;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Core.Disease> Diseases { get; set; }

        public void OnGet()
        {
            Diseases = diseaseData.GetDiseases(Name);
        }
    }
}