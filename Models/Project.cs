using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Constructor.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public int Master_Id { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Master_Id))]
        public Master Master { get; set; }
       
        public List<Deal> Deals { get; set; } = new List<Deal>();
    }
}