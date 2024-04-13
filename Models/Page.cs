using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public int Project_Id { get; set; }

        [ForeignKey(nameof(Project_Id))]
        public Project Project { get; set; }
    }
}
