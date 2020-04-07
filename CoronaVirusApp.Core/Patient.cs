using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Patient : Person
    {
        public Doctor Doctor { get; set; }
        [Required, Display (Name = "Doctor")]
        public int DoctorId { get; set; }        
    }
}
