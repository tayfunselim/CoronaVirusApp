using CoronaVirusApp.Core;
using CoronaVirusApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirusApp.DTOs
{
    public class PatientDto
    {
        [Required, StringLength(20, MinimumLength = 3), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Gender { get; set; }

        public Doctor Doctor { get; set; }
        [Required, Display(Name = "Doctor")]
        public int DoctorId { get; set; }
    }
}
