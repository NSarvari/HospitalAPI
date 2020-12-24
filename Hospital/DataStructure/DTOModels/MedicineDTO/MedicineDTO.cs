namespace DataStructure.DTOModels.MedicineDTO
{
    using System.Collections.Generic;

    public class MedicineDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<PatientMedicine> PatientBills { get; set; }
    }
}
