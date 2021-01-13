namespace DataStructure
{
    using System.Collections.Generic;

    public class Role:Model
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
