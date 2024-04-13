using System.Text.Json.Serialization;

namespace Constructor.Models
{
    public class Master
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<Project> Projects { get; set; }
        


    }
}
