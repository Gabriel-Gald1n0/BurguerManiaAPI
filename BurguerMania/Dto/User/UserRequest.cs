using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BurguerManiaAPI.Dto.User
{
    public class UserRequest
    {
    
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Nome deve ter entre 5 e 100 caracteres.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Email pode ter no máximo 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O Email deve ser um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "A Senha deve ter entre 6 e 8 caracteres.")]
        [JsonIgnore]
        public string? Password { get; set; }
    }
}