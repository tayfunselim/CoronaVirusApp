using CoronaVirusApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirusApp.DTOs
{
    public class AppointmentDto
    {   
        [Required, Display(Name = "Patient")]
        public int PatientId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public int Symptom { get; set; }
        public bool HasMedicalHistory { get; set; }
        public bool IsTested { get; set; }
        public bool IsForSelfIsolation { get; set; }
        public bool IsCoronaPositive { get; set; }
        public bool IsRecovered { get; set; }
        public bool IsDead { get; set; }
    }
}