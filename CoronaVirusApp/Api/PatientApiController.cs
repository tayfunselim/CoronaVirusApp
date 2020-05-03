using CoronaVirusApp.Core;
using CoronaVirusApp.Core.Enum;
using CoronaVirusApp.Data.Interfaces;
using CoronaVirusApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoronaVirusApp.Api
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientApiController : ControllerBase
    {
        private readonly IPatientData patientData;

        public PatientApiController(IPatientData patientData)
        {
            this.patientData = patientData;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var data = patientData.GetPatients();
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetPatient")]
        public IActionResult GetPatientById(int id)
        {
            var data = patientData.GetPatientById(id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest();
            }

            var patient = new Patient();
            patient.Age = patientDto.Age;
            patient.City = patientDto.City;
            patient.DoctorId = patientDto.DoctorId;
            patient.Gender = (Gender)patientDto.Gender;
            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;

            patientData.Create(patient);
            patientData.Commit();

            return CreatedAtRoute("GetPatient", new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult Update(PatientDto patientDto, int id)
        {
            var patient = patientData.GetPatientById(id);
            patient.Age = patientDto.Age;
            patient.City = patientDto.City;
            patient.DoctorId = patientDto.DoctorId;
            patient.Gender = (Gender)patientDto.Gender;
            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;

            patientData.Update(patient);
            patientData.Commit();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var temp = patientData.Delete(id);
            if (temp == null)
            {
                return BadRequest();
            }
            patientData.Commit();
            return NoContent();
        }

    }
}