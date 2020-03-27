using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IAppointmentData
    {
        IEnumerable<Appointment> GetAppointments(string name = null);
        Appointment Create(Appointment appointment);
        Appointment Delete(int appointmentid);
        int Commit();
    }
}
