using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Doctor : Person
    {
        //public Doctor()
        //{
        //    Appointments = new List<Appointment>();
        //}

        public string JobTitle { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        //public List<Appointment> Appointments { get; set; }
        //public int ClinicId { get; set; }
        //public Clinic Clinic { get; set; }
    }
}
