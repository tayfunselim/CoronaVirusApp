using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusApp.Core
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public string NameofAppointment { get; set; }
        public string Cause { get; set; }
        public int Feedback { get; set; }
        public double Bill { get; set; }
        public DateTime TestingDate { get; set; }
        public bool IsCoronaPositive { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public Symptom Symptom { get; set; }
        public bool IsApproved { get; set; }
    }
}
