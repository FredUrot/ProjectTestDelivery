using System.ComponentModel.DataAnnotations;
namespace ProjectTestDelivery.Models
{
    public class ItemVM
    {
        public List<Item> itemList { get; set; }
        public int? itemListCount { get; set; }
        public string? searchCustomerName { get; set; }
        public DateTime? searchDateMin { get; set; }
        public DateTime? searchDateMax   { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? searchByDate { get; set; }
        public int? status { get; set; }
        public string? searchAddress { get; set; }
        public string? searchCourierName { get; set; }
    }
}
