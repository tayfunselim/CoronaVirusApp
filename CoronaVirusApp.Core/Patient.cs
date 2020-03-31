using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Patient : Person
    {
        public List<Appointment> Appointments  { get; set; }
        public List<PatientDisease> Diseases { get; set; }
        public List<Doctor> Doctors { get; set; }        
        public bool IsTested { get; set; }              
        public bool IsForSelfIsolation { get; set; }        
        public MedicalHistory MedicalHistory { get; set; }
        public bool IsCoronaPositive { get; set; }
        public bool IsRecovered { get; set; }
        public bool IsDead { get; set; }        
    }
}
