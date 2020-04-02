using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaVirusApp.Data.Interfaces;
using CoronaVirusApp.Statistics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly CoronaStatistics coronaStatistics;
        private readonly IPatientData patientData;

        public StatisticsModel(IPatientData patientData, CoronaStatistics coronaStatistics)
        {
            this.patientData = patientData;
            this.coronaStatistics = coronaStatistics;
        }

        public IEnumerable<Core.Patient> Patients { get; set; }
        public int GetTotalPatients()
        {
            return coronaStatistics.TotalPatients();
        }

        public void OnGet()
        {
            
        }
    }
}