using System.ComponentModel.DataAnnotations;

namespace SIOMS.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}
