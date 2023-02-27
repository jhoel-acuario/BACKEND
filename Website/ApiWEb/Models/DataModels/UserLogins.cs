using System.ComponentModel.DataAnnotations;

namespace ApiWEb.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }= string.Empty;

    }
}
