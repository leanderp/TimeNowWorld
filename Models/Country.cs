using System.ComponentModel.DataAnnotations.Schema;

namespace TimeNowWorld.Models
{
    public class Country
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("timezone")]
        public string? TimeZone { get; set; }
    }
}
