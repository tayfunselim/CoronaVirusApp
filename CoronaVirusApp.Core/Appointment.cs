using System;
using System.ComponentModel.DataAnnotations;

namespace CoronaVirusApp.Core
{
    public class Appointment
    {
        public int Id { get; set; }        
        public Clinic Clinic { get; set; }
        
        [Required, Display(Name = "Clinic")]
        public int? ClinicId { get; set; }
        public Doctor Doctor { get; set; }
        
        [Required, Display(Name = "Doctor")]
        public int? DoctorId { get; set; }

        [Required]        
        public DateTime Date { get; set; }    
        public Symptom Symptom { get; set; }        
    }
}