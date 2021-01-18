namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.PatientMedicineDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class PatientMedicineController : ControllerBase
    {
        private readonly IPatientMedicineService _patientMedicineService;
        private readonly IMapper _mapper;

        public PatientMedicineController(IPatientMedicineService patientMedicineService, IMapper mapper)
        {
            _patientMedicineService = patientMedicineService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllPatientMedicines()
        {
            var patientMedicines = _patientMedicineService.GetAllPatientMedicines();
            return Ok(patientMedicines);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreatePatientMedicine([FromBody] PatientMedicineDTO patientMedicine)
        {
            PatientMedicineDTO newPatientMedicine = _patientMedicineService.CreatePatientMedicine(patientMedicine);
            return Ok(newPatientMedicine);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{patientId}/{medicineId}")]
        public IActionResult DeletePatientMedicine(int patientId, int medicineId)
        {
            _patientMedicineService.DeletePatientMedicine(patientId, medicineId);
            return Ok("Deleted successfully!");
        }
    }
}
