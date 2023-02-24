using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiWEb.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        //public int UserID { get; set; }
        public  string CreateBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }

        public string DeleteBY { get; set; }= string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDelete { get; set; }= false;
    }
}
