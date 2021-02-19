using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Item")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemPrice { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

    }
}