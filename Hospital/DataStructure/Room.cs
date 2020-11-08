namespace DataStructure
{
    using System.ComponentModel.DataAnnotations;

    public class Room : Model
    {
        [Required(ErrorMessage = "The field cannot be empty!")]
        public string WorkingPeriod { get; set; }

        [Required(ErrorMessage = "The field cannot be empty!")]
        public string RoomType { get; set; }

        //One to one relation
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
