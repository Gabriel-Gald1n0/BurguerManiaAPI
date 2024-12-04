using System.ComponentModel.DataAnnotations;

namespace BurguerManiaAPI.Dto.UserOrder
{
    public class UserOrderResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int OrderId { get; set; }
        public string? Status { get; set; }
        public float Value { get; set; }
    }
}