using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SIOMS.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIOMS.Models
{
    public class StockMovement
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; }

        public MovementType MovementType { get; set; }  // IN / OUT

        public int QuantityChanged { get; set; }         // + or -

        public int FinalStock { get; set; }             // stock after movement

        public DateTime MovementDate { get; set; } = DateTime.Now;

        public string? ReferenceNumber { get; set; }     // PO ID or SO ID
    }
}
