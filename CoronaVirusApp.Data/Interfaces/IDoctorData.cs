using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IDoctorData
    {
        IEnumerable<Doctor> GetDoctors(string name = null);
        Doctor CreateDoctor(Doctor doctor);
        Doctor DeleteDoctor(int id);
        Doctor Update(Doctor doctor);
        int Commit();

    }
}
