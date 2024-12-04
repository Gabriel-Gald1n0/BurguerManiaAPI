using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurguerManiaAPI.Models
{
    public class ProductsModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PathImage { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? FullDescription { get; set; }
        public int? CategoryId { get; set; }

        [JsonIgnore]
        public CategorysModel? Category { get; set; }
       
    }
}
