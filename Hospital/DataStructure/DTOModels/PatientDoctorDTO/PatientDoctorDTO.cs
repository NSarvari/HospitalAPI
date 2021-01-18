using System.Text.Json.Serialization;

namespace DataStructure.DTOModels.PatientDoctorDTO
{
    public class PatientDoctorDTO
    {
        public int PatientID { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }

        public int DoctorID { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
