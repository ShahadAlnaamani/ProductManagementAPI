using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }


        [MaxLength(50)]
        public string Category { get; set; }

        public DateTime DateAdded { get; set; }
    }
}

