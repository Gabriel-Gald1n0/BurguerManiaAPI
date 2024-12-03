using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurguerManiaAPI.Models
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
       
    }
}
