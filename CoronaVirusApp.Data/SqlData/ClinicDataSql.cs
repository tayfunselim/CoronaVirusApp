using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoronaVirusApp.Data.SqlData
{
    public class ClinicDataSql : IClinicData
    {
        private readonly CoronaVirusDbContext coronaVirusDbContext;

        public ClinicDataSql(CoronaVirusDbContext coronaVirusDbContext)
        {
            this.coronaVirusDbContext = coronaVirusDbContext;
        }
        public int Commit()
        {
            return coronaVirusDbContext.SaveChanges();
        }

        public Clinic Create(Clinic clinic)
        {
            coronaVirusDbContext.Clinics.Add(clinic);
            return clinic;
        }

        public Clinic Delete(int id)
        {
            var tempClinic = coronaVirusDbContext.Clinics.SingleOrDefault(c => c.Id == id);
            if (tempClinic != null)
            {
                coronaVirusDbContext.Clinics.Remove(tempClinic);
            }
            return tempClinic;
        }

        public Clinic GetClinicById(int id)
        {
            return coronaVirusDbContext.Clinics.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Clinic> GetClinics()
        {
            return coronaVirusDbContext.Clinics.ToList();
        }

        public IEnumerable<Doctor> GetDoctors(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatients(int id)
        {
            throw new NotImplementedException();
        }

        public Clinic Update(Clinic clinic)
        {
            coronaVirusDbContext.Entry(clinic).State = EntityState.Modified;
            return clinic;
        }
    }
}
