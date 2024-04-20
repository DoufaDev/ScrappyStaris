using ScrappyStaris.Models;

public class Movie{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Episode { get; set; }   
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    public string ReleaseDate { get; set; }
    public ICollection<CharacterMovie> Characters { get; set; } = [];
    public ICollection<MoviePlanet> Planets { get; set; } = [];
    public ICollection<MovieVehicle> Vehicles  { get; set; } = [];
    public ICollection<MovieStarship> Starships { get; set; } = [];
}