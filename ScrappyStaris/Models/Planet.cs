using ScrappyStaris.Models;

public record Planet {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Diameter { get; set; }
    public string RotationSpeed { get; set; }
    public string OrbitalPeriod { get; set; }
    public string Gravity { get; set; }
    public string Population { get; set; }
    public string Climate { get; set; }
    public string Terrain { get; set; }
    public string SurfaceWater { get; set; }
    public ICollection<CharacterPlanet> Characters { get; set; } = [];
    public ICollection<MoviePlanet> Movies { get; set; } = [];
}
