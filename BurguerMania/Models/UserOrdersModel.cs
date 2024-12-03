using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurguerManiaAPI.Models
{
    public class UserOrdersModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public OrdersModel? Order { get; set; }
        [JsonIgnore]
        public UsersModel? User { get; set; }
    }
}