namespace DataStructure.DTOModels.PatientDTO
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PatientDTO:ModelDTO
    {
        public string Name { get; set; }
        public string Sex { get; set; }

        public string AppointmentDate { get; set; }

        public string AppointmentHour { get; set; }

        public string ContactNumber { get; set; }

        [JsonIgnore]
        public ICollection<PatientDoctor> PatientAttendences { get; set; }

        [JsonIgnore]
        public ICollection<PatientMedicine> PatientBills { get; set; }

        [JsonIgnore]
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
