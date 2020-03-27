using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IClinicData
    {
        IEnumerable<Doctor> GetDoctors(int doctorid);
        IEnumerable<Patient> GetPatients(int patientid);
        int Commit();
    }
}
