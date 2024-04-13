using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Master_Id { get; set; }

        [ForeignKey(nameof(Master_Id))]
        public Master Master { get; set; }

        public List<Page> Pages { get; set; }

        public List<Deal> Deals { get; set; }
    }
}