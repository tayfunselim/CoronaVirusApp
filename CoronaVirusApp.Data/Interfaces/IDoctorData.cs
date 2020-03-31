using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IDoctorData
    {
        IEnumerable<Doctor> GetDoctors(string FirstName);
        Doctor GetDoctorById(int? id);
        Doctor Create (Doctor doctor);
        Doctor Delete (int id);
        Doctor Update (Doctor doctor);
        int Commit();
    }
}