namespace DataStructure.DTOModels.PatientDTO
{
    using System.Collections.Generic;

    public class PatientDTO:ModelDTO
    {
        public string Name { get; set; }
        public string Sex { get; set; }

        public string AppointmentDate { get; set; }

        public string AppointmentHour { get; set; }

        public string ContactNumber { get; set; }

        public ICollection<PatientDoctor> PatientAttendences { get; set; }
        public ICollection<PatientMedicine> PatientBills { get; set; }

        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
