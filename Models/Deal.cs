using System.ComponentModel.DataAnnotations.Schema;

namespace Constructor.Models
{
    public class Deal
    {
        public int Id { get; set; }        

        public int Amount { get; set; }

        public string Status { get; set; }

        public string ProductsName { get; set; }

        public string Comment { get; set; }

        public string Phone {  get; set; }

        public string Adress { get; set; }

        public DateTime Created { get; set; }

        public bool IsArchive { get; set; }

        public bool IsProblem { get; set; }

        public string Reason {  get; set; }

        public string ReasonComment { get; set; }

        public int Project_Id { get; set; }

        [ForeignKey(nameof(Project_Id))]
        public Project Project { get; set; }

        public int Client_Id { get; set; }

        [ForeignKey(nameof(Client_Id))]
        public Client Client { get; set; }
    }
}