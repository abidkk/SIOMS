using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SIOMS.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ValidateNever]
        public Supplier Supplier { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [ValidateNever]
        public List<PurchaseOrderItem> Items { get; set; } = new();

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }




    }
}
