using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBridgeInventory.Models
{
    public class Inventory
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max length for the field is 50 characters")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string MfgDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string ExpiryDate { get; set; }

        [MaxLength(50, ErrorMessage = "Max length for the field is 50 characters")]
        public string Description { get; set; }
    }
}
