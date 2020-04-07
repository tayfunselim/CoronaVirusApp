using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoronaVirusApp.Data.SqlData
{
    public class DoctorDataSql : IDoctorData
    {
        private readonly CoronaVirusDbContext coronaVirusDbContext;

        public DoctorDataSql(CoronaVirusDbContext coronaVirusDbContext)
        {
            this.coronaVirusDbContext = coronaVirusDbContext;
        }
        public int Commit()
        {
            return coronaVirusDbContext.SaveChanges();
        }

        public Doctor Create(Doctor doctor)
        {
            coronaVirusDbContext.Doctors.Add(doctor);
            return doctor;
        }

        public Doctor Delete(int id)
        {
            var tempDoctor = coronaVirusDbContext.Doctors.SingleOrDefault (d => d.Id == id);
            if (tempDoctor != null)
            {
                coronaVirusDbContext.Doctors.Remove(tempDoctor);
            }
            return tempDoctor;
        }

        public Doctor GetDoctorById(int? id)
        {
            return coronaVirusDbContext.Doctors.Include(d=>d.Clinic).SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return coronaVirusDbContext.Doctors.Include(d=>d.Clinic).ToList();
        }

        public Doctor Update(Doctor doctor)
        {
            coronaVirusDbContext.Entry(doctor).State = EntityState.Modified;
            return doctor;
        }
    }
}
