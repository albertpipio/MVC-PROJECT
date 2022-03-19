using System.ComponentModel.DataAnnotations;

namespace ERP_MVC_Project.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cif { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CompletedOrders { get; set; }
    }
}
