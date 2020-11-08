

namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor:Model
    {
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Speciality { get; set; }
        public string DoctorPhoto { get; set; }
        public ICollection<PatientDoctor> PatientAttendences { get; set; }

        //One to one relation
        public Room Room { get; set; }
    }
}
