namespace DataStructure.DTOModels.PatientDoctorDTO
{
    public class PatientDoctorDTO
    {
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
