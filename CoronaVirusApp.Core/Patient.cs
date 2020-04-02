using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Patient : Person
    {
        public Appointment Appointment { get; set; }

        [Required, Display (Name = "Appointment" )]
        public int? AppointmentId { get; set; }
        public Disease Disease { get; set; }
        
        [Required, Display(Name = "Disease")]
        public int? DiseaseId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public bool IsTested { get; set; }
        public bool IsForSelfIsolation { get; set; }
        public bool IsCoronaPositive { get; set; }
        public bool IsRecovered { get; set; }
        public bool IsDead { get; set; }
    }
}
