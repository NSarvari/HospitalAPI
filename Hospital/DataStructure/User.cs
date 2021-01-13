namespace DataStructure
{
    using System.Text.Json.Serialization;

    public class User:Model
    {
        public string Username { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
    }
}
