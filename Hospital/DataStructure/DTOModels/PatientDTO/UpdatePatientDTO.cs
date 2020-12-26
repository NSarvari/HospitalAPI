namespace DataStructure.DTOModels.PatientDTO
{
    public class UpdatePatientDTO : ModelDTO
    {
        public string AppointmentDate { get; set; }

        public string AppointmentHour { get; set; }

        public string ContactNumber { get; set; }
    }
}
