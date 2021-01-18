namespace DataStructure
{
    public class PatientDoctor
    {
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
