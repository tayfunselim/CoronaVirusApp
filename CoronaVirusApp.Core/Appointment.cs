using System;
using System.ComponentModel.DataAnnotations;

namespace CoronaVirusApp.Core
{
    public class Appointment
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        
        [Required, Display (Name = "Patient")]
        public int PatientId { get; set; }

        [Required]        
        public DateTime Date { get; set; }    
        public Symptom Symptom { get; set; }
        public bool HasMedicalHistory { get; set; }
        public bool IsTested { get; set; }
        public bool IsForSelfIsolation { get; set; }
        public bool IsCoronaPositive { get; set; }
        public bool IsRecovered { get; set; }
        public bool IsDead { get; set; }
    }
}