using System.ComponentModel;

namespace ProjectTestDelivery.Models
{
    public class Courier
    {
        public int? CourierId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Item>? ItemList { get; set; }
    }
}
