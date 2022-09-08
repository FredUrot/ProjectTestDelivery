using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTestDelivery.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [DisplayName("Courier ID")]
        public int? CourierId { get; set; }
        [Required(ErrorMessage = "Select an Owner")]
        [DisplayName("Customer ID")]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Courier? Courier { get; set; }    
        public List<SelectListItem>? AssignedCourier { get; set; }
        public List<SelectListItem>? Owner { get; set; }
        [Required]
        [DisplayName("Item Name")]
        public string ItemName { get; set; }
        [DisplayName("Item Description")]
        public string? ItemDescription { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DisplayName("Status")]
        public int StatusType { get; set; }
        [DisplayName("Proof")]
        public string? ProofName { get; set; }
        [DisplayName("Upload Proof")]
        public IFormFile? ProofFile { get; set; }
    }
}
