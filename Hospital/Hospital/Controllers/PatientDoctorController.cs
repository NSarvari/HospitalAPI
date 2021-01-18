namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.PatientDoctorDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]

    public class PatientDoctorController : ControllerBase
    {
        private readonly IPatientDoctorService _patientDoctorService;
        private readonly IMapper _mapper;

        public PatientDoctorController(IPatientDoctorService patientDoctorService, IMapper mapper)
        {
            _patientDoctorService = patientDoctorService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllPatientDoctors()
        {
            var patientDoctors = _patientDoctorService.GetAllPatientDoctors();
            return Ok(patientDoctors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreatePatientDoctor([FromBody] PatientDoctorDTO patientDoctor)
        {
            PatientDoctorDTO newPatientDoctor = _patientDoctorService.CreatePatientDoctor(patientDoctor);
            return Ok(newPatientDoctor);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{patientId}/{doctorId}")]
        public IActionResult DeletePatientDoctor(int patientId,int doctorId)
        {
            _patientDoctorService.DeletePatientDoctor(patientId,doctorId);
            return Ok("Deleted successfully!");
        }
    }
}
