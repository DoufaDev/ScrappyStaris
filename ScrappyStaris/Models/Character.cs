using ScrappyStaris.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Character{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BirthYear { get; set; }
    public string EyeColor  { get; set; }
    public string Gender { get; set; }
    public string HairColor { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string SkinColor { get; set; }
    public Planet? HomeWorld { get; set; }
    public ICollection<CharacterMovie> Movies { get; set; } = [];

}