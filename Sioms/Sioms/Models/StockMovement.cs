using System;
using System.ComponentModel.DataAnnotations;

namespace SIOMS.Models
{
    public enum MovementType { In, Out, Adjustment }

    public class StockMovement
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public MovementType MovementType { get; set; }
        public string Reason { get; set; }

        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    }
}
