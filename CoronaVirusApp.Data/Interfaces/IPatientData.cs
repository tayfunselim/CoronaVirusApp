using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IPatientData
    {
        IEnumerable<Patient> GetPatients(string searchName = null);
        Patient GetPatientById(int id);
        Patient Create(Patient patient);
        Patient Delete(int id);
        Patient Update(Patient patient);
        int Commit();        
    }
}
