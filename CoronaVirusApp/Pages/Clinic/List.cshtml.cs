using System.Collections.Generic;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Clinic
{
    public class ListModel : PageModel
    {
        private readonly IClinicData clinicData;

        public ListModel(IClinicData clinicData)
        {
            this.clinicData = clinicData;
        }       

        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Core.Clinic> Clinics { get; set; }

        public void OnGet()
        {
            Clinics = clinicData.GetClinics();
        }        
    }
}