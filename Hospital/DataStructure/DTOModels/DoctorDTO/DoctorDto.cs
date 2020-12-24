namespace DataStructure.DTOModels.DoctorDTO
{
    using System.Collections.Generic;

    public class DoctorDto
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string DoctorPhoto { get; set; }
        public ICollection<PatientDoctor> PatientAttendences { get; set; }
        public Room Room { get; set; }
    }
}
