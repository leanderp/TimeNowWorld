using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeNowWorld.Models;

public class Country
{
    [Column("id")]
    public int Id { get; set; }

    [Column("idCountry")]
    public int IdCountry { get; set; }

    [Column("nameEN")]
    public string? NameEN { get; set; }

    [Column("nameES")]
    public string? NameES { get; set; }

    [Column("capital")]
    public string? Capital { get; set; }

    [Column("continent")]
    public string? Continent { get; set; }

    [Column("timezone")]
    public string? TimeZone { get; set; }

    [Column("territory")]
    public string? Territory { get; set; }

    [Column("default")]
    public bool Default { get; set; }

    [NotMapped]
    public DateTime Time { get; set; }
}

