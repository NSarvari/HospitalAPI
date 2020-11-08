namespace DataStructure
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Model
    {
        [Key]

        public int Id { get; set; }
    }
}
