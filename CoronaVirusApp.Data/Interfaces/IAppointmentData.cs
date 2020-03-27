using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IAppointmentData
    {
        IEnumerable<Appointment> GetAppointments(string searchName = null);
        Appointment GetAppointmentById(int? id);
        Appointment Create(Appointment appointment);
        Appointment Delete(int id);
        Appointment Update(Appointment appointment);
        int Commit();
    }
}
