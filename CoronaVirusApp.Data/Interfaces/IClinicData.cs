using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Data.Interfaces
{
    public interface IClinicData
    {        
        int Commit();
        Clinic Create(Clinic clinic);
        Clinic Update(Clinic clinic);
        Clinic Delete(int id);
        Clinic GetClinicById(int? id);
        IEnumerable<Clinic> GetClinics ();
    }
}
