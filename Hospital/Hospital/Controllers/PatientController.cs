namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.PatientDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet("GetPatientById/{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _patientService.GetPatientById(id);
            return Ok(patient);
        }

        [HttpGet("GetPatientByName/{name}")]
        public IActionResult GetPatientByName(string name)
        {
            var patient = _patientService.GetPatientByName(name);
            return Ok(patient);
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] PatientDTO patient)
        {
            PatientDTO newPatient = _patientService.CreatePatient(patient);
            return CreatedAtRoute("PatientById", new { id = newPatient.Id }, newPatient);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] UpdatePatientDTO patient)
        {
            var updatedPatient = _patientService.UpdatePatient(id, patient);
            return Ok(updatedPatient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id, [FromBody] DeletePatientDTO patient)
        {
            var deletedPatient = _patientService.DeletePatient(id, patient);
            return NoContent();
        }
    }
}
