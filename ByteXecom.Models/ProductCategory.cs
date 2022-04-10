using System.ComponentModel.DataAnnotations;

namespace ByteXecom.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
