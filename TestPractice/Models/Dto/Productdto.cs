using System.ComponentModel.DataAnnotations;

namespace TestPractice.Models.Dto
{
    public class Productdto
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
