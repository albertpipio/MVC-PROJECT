using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP_MVC_Project.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
