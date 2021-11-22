using System.ComponentModel.DataAnnotations.Schema;

namespace TimeNowWorld.Models;
public class Country
{   
    private string? _nameEN;
    private string? _nameES;
    
    [Column("id")]
    public int Id { get; set; }

    [Column("idCountry")]
    public int IdCountry { get; set; }

    [Column("nameEN")]
    public string NameEN { get => _nameEN ?? throw new InvalidOperationException("Unitialized property: " + nameof(NameEN)); set => _nameEN = value; }

    [Column("nameES")]
    public string? NameES { get => _nameES ?? throw new InvalidOperationException("Unitialized property: " + nameof(NameEN)); set => _nameES = value; }

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

