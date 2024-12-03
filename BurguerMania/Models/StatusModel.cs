using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurguerManiaAPI.Models
{
    public class StatusModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        
    }
}