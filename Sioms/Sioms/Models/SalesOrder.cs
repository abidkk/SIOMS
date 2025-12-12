using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SIOMS.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [ValidateNever]
        public List<SalesOrderItem> Items { get; set; } = new();

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
    }
}
