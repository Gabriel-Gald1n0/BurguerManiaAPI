using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurguerManiaAPI.Models
{
    public class OrderProductsModel
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        public int OrderId { get; set; }
        
        [JsonIgnore]
        public ProductsModel? Product { get; set; }
        
        [JsonIgnore]
        public OrdersModel? Order { get; set; }
        
    }
}