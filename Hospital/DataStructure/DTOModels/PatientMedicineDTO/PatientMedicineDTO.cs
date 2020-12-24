namespace DataStructure.DTOModels.PatientMedicineDTO
{
    public class PatientMedicineDTO
    {
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int MedicineID { get; set; }
        public Medicine Medicine { get; set; }
    }
}
