namespace DataStructure.DTOModels.MedicineDTO
{
    public class DeleteMedicineDTO:ModelDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
