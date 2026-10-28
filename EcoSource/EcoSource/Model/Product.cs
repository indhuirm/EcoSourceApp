using System.ComponentModel.DataAnnotations;

namespace EcoSource.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string product_name { get; set; } = string.Empty;

    }
}
