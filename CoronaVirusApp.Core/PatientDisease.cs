using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class PatientDisease
    {
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
