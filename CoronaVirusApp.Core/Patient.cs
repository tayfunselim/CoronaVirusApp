using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Patient
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public List<Disease> Diseases { get; set; }
        public Patient()
        {
            Person = new Person();
            Diseases = new List<Disease>();
        }

        public DateTime FirstSymptoms { get; set; }
        public List<string> Symptoms { get; set; }
        public bool IsTested { get; set; }        
        public DateTime DateofCuring { get; set; }
        public bool IsForSelfIsolation { get; set; }
        public string Insurance { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public Doctor Doctor { get; set; }
        public string Statement { get; set; }


        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
