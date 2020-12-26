namespace DataStructure.DTOModels.DoctorDTO
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class DoctorDTO:ModelDTO
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string DoctorPhoto { get; set; }

        [JsonIgnore]
        public ICollection<PatientDoctor> PatientAttendences { get; set; }
        public Room Room { get; set; }
    }
}
