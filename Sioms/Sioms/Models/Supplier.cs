using System.ComponentModel.DataAnnotations;

namespace SIOMS.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
