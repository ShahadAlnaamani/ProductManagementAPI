using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.DTOs
{
    public class ProductInputDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required] //must be more than 0
        public decimal Price { get; set; }
        
        [DefaultValue("general")]
        public string Category { get; set; }

    }
}
