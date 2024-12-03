using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurguerManiaAPI.Models
{
    public class OrdersModel
    {
        [Key]
        public int Id { get; set; }
        public int StatusId { get; set; }
        public float Value { get; set; }
        [JsonIgnore]
        public StatusModel? Status { get; set; }
    }
}