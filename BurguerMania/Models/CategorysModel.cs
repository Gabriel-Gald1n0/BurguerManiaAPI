using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace BurguerManiaAPI.Models
{
    public class CategorysModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PathImage { get; set; }
       
        public ICollection<ProductsModel> Products { get; set; } = new List<ProductsModel>();
    }
}
