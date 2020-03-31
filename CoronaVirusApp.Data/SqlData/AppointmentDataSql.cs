using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoronaVirusApp.Data.SqlData
{
    public class AppointmentDataSql : IAppointmentData
    {
        private readonly CoronaVirusDbContext coronaVirusDbContext;

        public AppointmentDataSql(CoronaVirusDbContext coronaVirusDbContext)
        {
            this.coronaVirusDbContext = coronaVirusDbContext;
        }
        public int Commit()
        {
            return coronaVirusDbContext.SaveChanges();
        }

        public Appointment Create(Appointment appointment)
        {
            coronaVirusDbContext.Appointments.Add(appointment);
            return appointment;
        }

        public Appointment Delete(int id)
        {
            var tempAppointment = coronaVirusDbContext.Appointments.SingleOrDefault(a => a.Id == id);
            if (tempAppointment != null)
            {
                coronaVirusDbContext.Appointments.Remove(tempAppointment);
            }
            return tempAppointment;
        }

        public Appointment GetAppointmentById(int? id)
        {
            return coronaVirusDbContext.Appointments.SingleOrDefault(a=>a.Id == id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {            
            return coronaVirusDbContext.Appointments
                .Include(a=>a.Clinic)         
                .ToList();
        }

        public Appointment Update(Appointment appointment)
        {
            coronaVirusDbContext.Entry(appointment).State = EntityState.Modified;
            return appointment;
        }
    }
}
