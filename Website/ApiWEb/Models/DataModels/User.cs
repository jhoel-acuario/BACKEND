
using System.ComponentModel.DataAnnotations;

namespace ApiWEb.Models.DataModels
{
    public class User:BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }= string.Empty;
        [Required, StringLength(100)]
        public string Lastname { get; set; } = string.Empty;
        [Required,EmailAddress] 
        public string Email { get; set; }= string.Empty;
        [Required]
        public string Password { get; set; }= string.Empty;

    }
}
