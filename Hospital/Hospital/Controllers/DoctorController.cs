namespace Hospital.Controllers
{
    using DataAccess;
    using DataAccess.IRepositories;
    using DataStructure;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        protected ApplicationDbContext Context { get; set; }

        public DoctorController(IDoctorRepository doctorRepository, ApplicationDbContext context)
        {
            _doctorRepository = doctorRepository;
            Context = context;
        }

        [HttpGet("{id}", Name = "DoctorById")]
        public IActionResult GetDoctorById(int id)
        {
            var doctors = _doctorRepository.GetDoctorById(id);
            return Ok(doctors);
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult CreateDoctor([FromBody] Doctor doctor)
        {
            _doctorRepository.CreateDoctor(doctor);
            Context.SaveChanges();
            return CreatedAtRoute("DoctorById", new { id = doctor.Id }, doctor);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            _doctorRepository.UpdateDoctor(doctor);
            _doctorRepository.Save();
            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(Doctor doctor)
        {
            _doctorRepository.DeleteDoctor(doctor);
            _doctorRepository.Save();
            return NoContent();
        }
    }
}
