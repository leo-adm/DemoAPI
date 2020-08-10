using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }
    }
}
