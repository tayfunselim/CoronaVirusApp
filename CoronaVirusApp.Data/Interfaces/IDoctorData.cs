using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IDoctorData
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorById(string id);
        Doctor Create (Doctor doctor);
        Doctor Delete (string id);
        Doctor Update (Doctor doctor);
        int Commit();
    }
}