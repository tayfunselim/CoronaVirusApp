using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusAppStatistics
{
    public class Statistics
    {
        private readonly IPatientData patientData;

        public Statistics(IPatientData patientData)
        {
            this.patientData = patientData;
        }

        public int GetTotalCoronaCases(Patient patient)
        {
            var result = 0;
            foreach (var item in patient.IsCoronaPositive.ToString())
            {
                if (patient.IsCoronaPositive)
                {
                    result++;
                }                
            }
            return result;
        }
        public int GetTotalRecoveries (Patient patient)
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
        public int GetActiveCoronaCases ()
        {
            var patient = new Patient();
            return GetTotalCoronaCases(patient) - GetTotalRecoveries(patient) - GetTotalDeaths(patient);
        }

    }
}
