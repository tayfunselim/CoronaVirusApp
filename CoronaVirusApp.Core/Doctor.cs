using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Doctor : Person
    {
        public Clinic Clinic { get; set; }

        [Required, Display (Name = "Clinic")]
        public int ClinicId { get; set; }        
    }
}