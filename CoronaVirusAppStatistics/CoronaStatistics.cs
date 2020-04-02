using CoronaVirusApp.Core;
using CoronaVirusApp.Data;
using CoronaVirusApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaVirusApp.Statistics
{
    public class CoronaStatistics
    {
        
        private readonly IPatientData patientData;
        private readonly CoronaVirusDbContext coronaVirusDbContext;

        public CoronaStatistics(IPatientData patientData, CoronaVirusDbContext coronaVirusDbContext)
        {
            this.patientData = patientData;
            this.coronaVirusDbContext = coronaVirusDbContext;
        }

        public int TotalPatients()
        {
            return coronaVirusDbContext.Patients.Count();
        }
        public int TotalCoronaCases(Patient patient)
        {
            var result = 0;
            foreach (var item in coronaVirusDbContext.Patients.Where(p => p.IsCoronaPositive))
            {
                if (patient.IsCoronaPositive)
                {
                    result++;
                }
            }
            return result;
        }
        public int TotalRecoveries (Patient patient)
        {
            var result = 0;
            foreach (var item in patient.IsRecovered.ToString())
            {
                if (patient.IsRecovered)
                {
                    result++;
                }
            }
            return result;
        }

        public int GetTotalDeaths(Patient patient)
        {
            var result = 0;
            foreach (var item in patient.IsDead.ToString())
            {
                if (patient.IsRecovered)
                {
                    result++;
                }
            }
            return result;
        }
        //public int GetActiveCoronaCases ()
        //{
        //    var patient = new Patient();
        //    return GetTotalCoronaCases(patient) - GetTotalRecoveries(patient) - GetTotalDeaths(patient);
        //}

    }
}
