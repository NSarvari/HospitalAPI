namespace DataStructure.DTOModels.RoomDTO
{
    public class RoomDTO:ModelDTO
    {
        public string WorkingPeriod { get; set; }
        public string RoomType { get; set; }
        public Doctor Doctor { get; set; }
    }
}
