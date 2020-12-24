namespace DataStructure
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medicine:Model
    {
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field ccannot be empty!")]
        public int Quantity { get; set; }

        //Many to many relations
        public ICollection<PatientMedicine> PatientBills { get; set; }
    }
}
