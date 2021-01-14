using System.Text.Json.Serialization;

namespace DataStructure
{
    public class PatientMedicine
    {
        public int PatientID { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }

        public int MedicineID { get; set; }
        
        [JsonIgnore]
        public Medicine Medicine { get; set; }
    }
}
