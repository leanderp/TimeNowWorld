using TimeNowWorld.Models.DTOs;

namespace TimeNowWorld.Models;

public class TargetTime
{
    public CountyDTO MyCountry { get; set; }
    public List<CountyDTO> TargetCountries { get; set; }
}

