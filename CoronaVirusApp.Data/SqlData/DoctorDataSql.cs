using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Doctor GetDoctorById(int id)
        {
            return coronaVirusDbContext.Doctors.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return coronaVirusDbContext.Doctors.ToList();
        }

        public Doctor Update(Doctor doctor)
        {
            coronaVirusDbContext.Entry(doctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return doctor;
        }
    }
}
