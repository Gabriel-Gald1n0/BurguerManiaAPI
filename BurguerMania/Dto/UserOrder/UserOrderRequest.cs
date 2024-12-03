using System.ComponentModel.DataAnnotations;

namespace BurguerManiaAPI.Dto.UserOrder
{
    public class UserOrderRequest
    {
        [Required(ErrorMessage = "O ClienteId é obrigatório.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "O PedidoId é obrigatório.")]
        public int OrderId { get; set; }
    }
}