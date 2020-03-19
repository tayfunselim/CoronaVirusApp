using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Patient
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Patient()
        {
            Person = new Person();
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
        public Appointment Appointment { get; set; }

        public Disease Disease { get; set; }
        public int DiseaseId { get; set; }
    }
}
