using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Patient
{
    public class ListModel : PageModel
    {
        private readonly IPatientData patientData;

        public ListModel(IPatientData patientData)
        {
            this.patientData = patientData;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Core.Patient> Patients { get; set; }

        public void OnGet()
        {
            Patients = patientData.GetPatients(SearchName);
        }
    }
}