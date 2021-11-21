namespace TimeNowWorld.Models.DTOs
{
    public class CountyDTO
    {
        public int Id { get; set; }

        public int IdCountry { get; set; }

        public string? NameEN { get; set; }

        public string? NameES { get; set; }

        public string? TimeZone { get; set; }

        public DateTime Time { get; set; }
    }
}
