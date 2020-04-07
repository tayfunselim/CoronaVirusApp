using System.Collections.Generic;
using CoronaVirusApp.Data.Interfaces;
using CoronaVirusApp.Statistics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaVirusApp.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly CoronaStatistics coronaStatistics;
        private readonly IPatientData patientData;
        private readonly IAppointmentData appointmentData;

        public StatisticsModel(IPatientData patientData, IAppointmentData appointmentData, CoronaStatistics coronaStatistics)
        {
            this.patientData = patientData;
            this.appointmentData = appointmentData;
            this.coronaStatistics = coronaStatistics;
        }    

        public IEnumerable<Core.Patient> Patients { get; set; }
        public IEnumerable<Core.Appointment> Appointments { get; set; }
        public int GetTotalPatients()
        {
            return coronaStatistics.TotalPatients();
        }
        
        public int GetActiveCases()
        {
            return coronaStatistics.ActiveCases();
        }
        
        public void OnGet()
        {
            Patients = patientData.GetPatients();
            Appointments = appointmentData.GetAppointments();            
        }
    }
}