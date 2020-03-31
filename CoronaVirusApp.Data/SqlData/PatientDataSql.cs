using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return coronaVirusDbContext.Patients                
                .Include (p => p.Appointment)
                .Include(p => p.Diseases)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Patient> GetPatients(string searchName = null)
        {
            return coronaVirusDbContext.Patients
                .Include(p => p.Appointment)
                .Include (p => p.Diseases)
                .Where(p => string.IsNullOrEmpty(searchName)
                   || p.FirstName.ToLower().StartsWith(searchName.ToLower())
                   || p.LastName.ToLower().StartsWith(searchName.ToLower()))
                .OrderBy(p => p.FirstName)
                .ToList();
        }

        public Patient Update(Patient patient)
        {
            coronaVirusDbContext.Entry(patient).State = EntityState.Modified;
            return patient;
        }
    }
}
