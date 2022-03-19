using System.ComponentModel.DataAnnotations;

namespace ERP_MVC_Project.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PastOrders { get; set; }
        public string CompletedOrders { get; set; }
        public decimal? Salary { get; set; }
    }
}
