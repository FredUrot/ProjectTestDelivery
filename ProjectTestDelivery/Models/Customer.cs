using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTestDelivery.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Item>? ItemList { get; set; }
    }
}
