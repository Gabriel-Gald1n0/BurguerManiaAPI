using System.ComponentModel.DataAnnotations;

namespace BurguerManiaAPI.Dto.Category
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "A Descricao pode ter no máximo 150 caracteres e no minimo 6.")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "O PathImage é obrigatório.")]
        public string? PathImage { get; set; }
    }
}