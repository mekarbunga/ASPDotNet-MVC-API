
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("Tb_M_Supplier")]
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [MinLength(6, ErrorMessage = "Minimum 6 characters")]
        [StringLength(255, MinimumLength = 6)]
        [RegularExpression("^[A-Za-z0-9]*$")]
        public string SupplierName { get; set; }
    }
}