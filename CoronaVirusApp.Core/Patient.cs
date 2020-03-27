using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Patient : Person
    {
        public List<Disease> Diseases { get; set; }
        public Patient()
        {
            Diseases = new List<Disease>();
        }

        public DateTime FirstSymptoms { get; set; }
        
        public bool IsTested { get; set; }        
        public DateTime DateofCuring { get; set; }
        public bool IsForSelfIsolation { get; set; }
        public bool IsInsured { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public string Statement { get; set; }

        //public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
        //public int ClinicId { get; set; }
        //public Clinic Clinic { get; set; }

        //public int AppointmentId { get; set; }
        //public Appointment Appointment { get; set; }
        //public List<string> Symptoms { get; set; }
    }
}
