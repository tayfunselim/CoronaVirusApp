﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages.Patient
{
    public class DetailsModel : PageModel
    {
        private readonly IPatientData patientData;
        public Core.Patient Patient { get; set; }
        public DetailsModel(IPatientData patientData)
        {
            this.patientData = patientData;
        }

        public IActionResult OnGet(int id)
        {
            Patient = patientData.GetPatientById(id);
            if (Patient == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}