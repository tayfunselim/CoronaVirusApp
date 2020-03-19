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
        public DiseaseType  DiseaseType { get; set; }
        public string Descritpion { get; set; }
        public string DinamikanaProtekuvanje { get; set; }
        public string Lekuvanje { get; set; }

        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
    }
}
