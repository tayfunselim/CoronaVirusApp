using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Appointment
    {
        public int Id { get; set; }        
        public Clinic Clinic { get; set; }
        
        [Required, Display(Name = "Clinic")]
        public int? ClinicId { get; set; }
        [Required]
        public string NameofAppointment { get; set; }
        [Required]
        public string Cause { get; set; }        
        public double Bill { get; set; }
        public DateTime TestingDate { get; set; }
        public bool IsCoronaPositive { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public Symptom Symptom { get; set; }        
    }
}
