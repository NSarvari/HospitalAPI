namespace DataStructure.DTOModels.MedicalRecordDTO
{
    public class MedicalRecordDTO
    {
        public string DateOfExamination { get; set; }
        public string Diagnosis { get; set; }
        public Patient Patient { get; set; }
    }
}
