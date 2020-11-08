namespace DataStructure
{
    public class PatientMedicine
    {
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int MedicineID { get; set; }
        public Medicine Medicine { get; set; }
    }
}
