using CoronaVirusApp.Core;
using CoronaVirusApp.Data.Interfaces;
using CoronaVirusApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoronaVirusApp.Api
{
    [Route("api/Appointments")]
    [ApiController]
    public class AppointmentApiController : ControllerBase
    {
        private readonly IAppointmentData appointmentData;

        public AppointmentApiController(IAppointmentData appointmentData)
        {
            this.appointmentData = appointmentData;
        }

        [HttpGet]
        public IActionResult GetAppointmentsAll()
        {
            var data = appointmentData.GetAppointments();
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetAppointment")]
        public IActionResult GetAppointmentId(int id)
        {
            var data = appointmentData.GetAppointmentById(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest();
            }

            var appointment = new Appointment();
            appointment.Date = appointmentDto.Date;
            appointment.HasMedicalHistory = appointmentDto.HasMedicalHistory;
            appointment.IsCoronaPositive = appointmentDto.IsCoronaPositive;
            appointment.IsDead = appointmentDto.IsDead;
            appointment.IsForSelfIsolation = appointmentDto.IsForSelfIsolation;
            appointment.IsRecovered = appointmentDto.IsRecovered;
            appointment.IsTested = appointmentDto.IsTested;
            appointment.PatientId = appointmentDto.PatientId;

            appointmentData.Create(appointment);
            appointmentData.Commit();

            return CreatedAtRoute("GetAppointment", new { id = appointment.Id }, appointment);
        }

    }
}