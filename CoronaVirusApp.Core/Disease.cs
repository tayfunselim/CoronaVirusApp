using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Disease
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public double DeathRate { get; set; } // in percentage
        public DiseaseType DiseaseType { get; set; }                        
    }
}