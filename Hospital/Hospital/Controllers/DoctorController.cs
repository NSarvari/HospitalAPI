namespace Hospital.Controllers
{
    using AutoMapper;
    using DataStructure.DTOModels.DoctorDTO;
    using Hospital.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{id}", Name = "DoctorById")]
        public IActionResult GetDoctorById(int id)
        {
            var doctors = _doctorService.GetDoctorById(id);
            return Ok(doctors);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateDoctor([FromBody] DoctorDTO doctor)
        {
            DoctorDTO newDoctor = _doctorService.CreateDoctor(doctor);
            return CreatedAtRoute("DoctorById", new { id = newDoctor.Id }, newDoctor);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id,[FromBody] UpdateDoctorDTO doctor)
        {
            var updatedDoctor = _doctorService.UpdateDoctor(id, doctor);
            return Ok(updatedDoctor);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id, [FromBody] DeleteDoctorDTO doctor)
        {
            _doctorService.DeleteDoctor(id, doctor);
            return NoContent();
        }
    }
}
