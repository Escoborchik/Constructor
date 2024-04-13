using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Models
{
    public class Deal
    {
        public int Id { get; set; }        

        public int Amount { get; set; }

        public string Status { get; set; }

        public int Project_Id { get; set; }

        [ForeignKey(nameof(Project_Id))]
        public Project Project { get; set; }

        public int Client_Id { get; set; }

        [ForeignKey(nameof(Client_Id))]
        public Client Client { get; set; }
    }
}