using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaVirusApp.Data.SqlData
{
    public class PatientDataSql : IPatientData
    {
        private readonly CoronaVirusDbContext coronaVirusDbContext;

        public PatientDataSql(CoronaVirusDbContext coronaVirusDbContext)
        {
            this.coronaVirusDbContext = coronaVirusDbContext;
        }
        public int Commit()
        {
            return coronaVirusDbContext.SaveChanges();
        }

        public Patient Create(Patient patient)
        {
            coronaVirusDbContext.Patients.Add(patient);
            return patient;
        }

        public Patient Delete(int id)
        {
            var tempPatient = coronaVirusDbContext.Patients.SingleOrDefault (p => p.Id == id);
            if (tempPatient != null)
            {
                coronaVirusDbContext.Patients.Remove(tempPatient);
            }
            return tempPatient;
        }

        public Patient GetPatientById(int id)
        {
            return coronaVirusDbContext.Patients.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Patient> GetPatients(string searchName = null)
        {
            return coronaVirusDbContext.Patients
                .Where(p => string.IsNullOrEmpty(searchName)
                   || p.FirstName.ToLower().StartsWith(searchName.ToLower())
                   || p.LastName.ToLower().StartsWith(searchName.ToLower()))
                .OrderBy(p => p.FirstName)
                .ToList();
        }

        public Patient Update(Patient patient)
        {
            coronaVirusDbContext.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return patient;
        }
    }
}
