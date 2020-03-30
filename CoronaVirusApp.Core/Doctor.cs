using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Doctor : Person
    {        
        public string JobTitle { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }        
    }
}