using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeNowWorld.Models
{
    public class Country
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column("name")]
        public string? Name { get; set; }
        
        [Column("timezone")]
        public string? TimeZone { get; set; }
    }
}
