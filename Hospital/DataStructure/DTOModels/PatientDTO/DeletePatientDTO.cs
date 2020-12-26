namespace DataStructure.DTOModels.PatientDTO
{
    public class DeletePatientDTO:ModelDTO
    {
        public string Name { get; set; }
        public string Sex { get; set; }

        public string AppointmentDate { get; set; }

        public string AppointmentHour { get; set; }

        public string ContactNumber { get; set; }

    }
}
