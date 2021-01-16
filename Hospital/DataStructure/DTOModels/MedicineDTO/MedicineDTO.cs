namespace DataStructure.DTOModels.MedicineDTO
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MedicineDTO:ModelDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public ICollection<PatientMedicine> PatientBills { get; set; }
    }
}
