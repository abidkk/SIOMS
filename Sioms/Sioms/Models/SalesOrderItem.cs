using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIOMS.Models
{
    public class SalesOrderItem
    {
        public int Id { get; set; }

        [Required]
        public int SalesOrderId { get; set; }

        [ValidateNever]
        public SalesOrder SalesOrder { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }   // Quantity sold

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public decimal LineTotal => Quantity * UnitPrice;
    }
}
