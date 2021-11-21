using System.ComponentModel.DataAnnotations;

namespace TimeNowWorld.Models.DTOs
{
    public class CountyDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdCountry { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? TimeZone { get; set; }
        public DateTime Time { get; set; }
    }
}
