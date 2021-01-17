namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.MedicalRecordDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IMapper _mapper;

        public MedicalRecordController(IMedicalRecordService medicalRecordService, IMapper mapper)
        {
            _medicalRecordService = medicalRecordService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetMedicalRecordById/{id}")]
        public IActionResult GetMedicalRecordById(int id)
        {
            var medicalRecord = _medicalRecordService.GetMedicalRecordById(id);
            return Ok(medicalRecord);
        }

        [Authorize]
        [HttpGet("GetMedicalRecordByDate/{name}")]
        public IActionResult GetMedicalRecordByDate(string date)
        {
            var medicalRecord = _medicalRecordService.GetMedicalRecordByDate(date);
            return Ok(medicalRecord);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllMedicalRecords()
        {
            var medicalRecords = _medicalRecordService.GetAllMedicalRecords();
            return Ok(medicalRecords);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateMedicine([FromBody] MedicalRecordDTO medicalRecord)
        {
            MedicalRecordDTO newMedicalRecord = _medicalRecordService.CreateMedicalRecord(medicalRecord);
            return CreatedAtRoute("MedicalRecordById", new { id = newMedicalRecord.Id }, newMedicalRecord);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateMedicalRecord(int id, [FromBody] UpdateMedicalRecordDTO medicalRecord)
        {
            var updateMedicalRecord = _medicalRecordService.UpdateMedicalRecord(id, medicalRecord);
            return Ok(updateMedicalRecord);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalRecord(int id, [FromBody] DeleteMedicalRecordDTO medicalRecord)
        {
            _medicalRecordService.DeleteMedicalRecord(id, medicalRecord);
            return NoContent();
        }
    }
}
