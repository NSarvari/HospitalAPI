namespace DataStructure
{
    using System.ComponentModel.DataAnnotations;

    public class MedicalRecord:Model
    {
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string DateOfExamination { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Diagnosis { get; set; }

        //One to many relations
        public Patient Patient { get; set; }
    }
}
