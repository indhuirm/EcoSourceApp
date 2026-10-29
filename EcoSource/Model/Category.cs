using System.ComponentModel.DataAnnotations;

namespace EcoSource.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string ? CategoryName { get; set; }
    }
}
