using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SpreadingDate { get; set; }
        public double DeathRate { get; set; } // in percentage
        public DiseaseType DiseaseType { get; set; }
        public string Description { get; set; }        
        public string Treatment { get; set; }        
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}