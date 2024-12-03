using System.ComponentModel.DataAnnotations;

namespace BurguerManiaAPI.Dto.OrderProduct
{
    public class OrderProductRequest
    {
        [Required(ErrorMessage = "O PedidoId é obrigatório.")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "O ProdutoId é obrigatório.")]
        public int ProductId { get; set; }
    }
}