namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.MedicineDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public MedicineController(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetMedicineById/{id}")]
        public IActionResult GetMedicineById(int id)
        {
            var medicine = _medicineService.GetMedicineById(id);
            return Ok(medicine);
        }

        [Authorize]
        [HttpGet("GetMedicineByName/{name}")]
        public IActionResult GetMedicineByName(string name)
        {
            var medicine = _medicineService.GetMedicineByName(name);
            return Ok(medicine);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllMedicines()
        {
            var medicines = _medicineService.GetAllMedicines();
            return Ok(medicines);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateMedicine([FromBody] MedicineDTO medicine)
        {
            MedicineDTO newMedicine = _medicineService.CreateMedicine(medicine);
            return CreatedAtRoute("MedicineById", new { id = newMedicine.Id }, newMedicine);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateMedicine(int id, [FromBody] UpdateMedicineDTO medicine)
        {
            var updatedMedicine = _medicineService.UpdateMedicine(id, medicine);
            return Ok(updatedMedicine);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(int id, [FromBody] DeleteMedicineDTO medicine)
        {
            _medicineService.DeleteMedicine(id, medicine);
            return NoContent();
        }
    }
}
