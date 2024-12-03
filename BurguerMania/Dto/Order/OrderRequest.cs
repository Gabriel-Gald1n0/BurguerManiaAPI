using System.ComponentModel.DataAnnotations;

namespace BurguerManiaAPI.Dto.Order
{
    public class OrderRequest
    {
        [Required(ErrorMessage = "O StatusId é obrigatório.")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "O Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public float Value { get; set; }
    }
}