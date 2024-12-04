using System.ComponentModel.DataAnnotations;

namespace BurguerManiaAPI.Dto.Product
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "O Nome deve ter entre 6 e 100 caracteres.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A Imagem é obrigatória.")]
        public string? PathImage { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [Range(0.01,  999.99, ErrorMessage = "O Preço deve estar entre 0,01 e 999,99.")]
        public decimal Price { get; set; }  = 10.00m; 

        [Required(ErrorMessage = "A Categoria é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A Categoria deve ser maior que 0.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [StringLength(150, MinimumLength = 6,ErrorMessage = "A Base Description pode ter no máximo 150 caracteres e no minimo 6.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O Texto sobre é obrigatória.")]
        [StringLength(1000, MinimumLength = 6,ErrorMessage = "A FullDescription pode ter no máximo 1000 caracteres e no minimo 6.")]
        public string? FullDescription { get; set; }
        
    }
}