using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIOMS.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int MinimumStockLevel { get; set; }
    }
}


//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace SIOMS.Models
//{
//    public class Product
//    {
//        public int Id { get; set; }

//        [Required]
//        public string Name { get; set; }

//        public string Description { get; set; }

//        public int CategoryId { get; set; }
//        public Category Category { get; set; }

//        public int? SupplierId { get; set; }
//        public Supplier Supplier { get; set; }

//        [Column(TypeName = "decimal(18,2)")]
//        public decimal Price { get; set; }

//        public int StockQuantity { get; set; }

//        public int MinimumStockLevel { get; set; }
//    }
//}
