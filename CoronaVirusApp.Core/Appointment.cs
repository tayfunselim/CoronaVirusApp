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
        public DateTime Date { get; set; }        
        
        public Symptom Symptom { get; set; }        
    }
}