using CoronaVirusApp.Core;
using CoronaVirusApp.Data;
using CoronaVirusApp.Data.Interfaces;
using System.Linq;

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
        public int TotalPatientsByCity(Patient patient)
        {
            return coronaVirusDbContext.Patients.Count();
        }
        public int TotalCoronaCases()
        {
            var result = 0;
            foreach (var item in coronaVirusDbContext.Appointments.ToList())
            {
                if (item.IsCoronaPositive == true)
                {
                    result++;
                }
            }
            return result;
        }
        public int TotalRecoveries ()
        {
            var result = 0;
            foreach (var item in coronaVirusDbContext.Appointments.ToList())
            {
                if (item.IsRecovered == true)
                {
                    result++;
                }
            }
            return result;
        }

        //public int TotalDeaths()
        //{
        //    var result = 0;
        //    foreach (var item in coronaVirusDbContext.Appointments.ToList())
        //    {
        //        if (item.IsDead == true)
        //        {
        //            result++;
        //        }
        //    }
        //    return result;
        //}
        //public int ActiveCases()
        //{
        //    return TotalCoronaCases() - TotalRecoveries() - TotalDeaths();
        //}
    }
}