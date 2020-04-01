using System.Collections.Generic;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Doctor
{
    public class ListModel : PageModel
    {
        private readonly IDoctorData doctorData;

        public ListModel(IDoctorData doctorData)
        {
            this.doctorData = doctorData;
        }        

        [TempData]
        public string TempMessage { get; set; }

        public IEnumerable<Core.Doctor> Doctors{ get; set; }

        public void OnGet()
        {
            Doctors = doctorData.GetDoctors();
        }
    }
}