namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient:Model
    { 
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string AppointmentDate { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string AppointmentHour { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string ContactNumber { get; set; }

        //Many to many relations
        public ICollection<PatientDoctor> PatientAttendences { get; set; }
        public ICollection<PatientMedicine> PatientBills { get; set; }

        //One to many relations
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
