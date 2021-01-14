using System.Text.Json.Serialization;

namespace DataStructure
{
    public class PatientDoctor
    {
        public int PatientID { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }

        public int DoctorID { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
