using System.ComponentModel.DataAnnotations;

namespace ERP_MVC_Project.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Client { get; set; }
        public string Employee { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public string DateOfAssignment { get; set; }
        public string DateOfCompletion { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
    }
}
