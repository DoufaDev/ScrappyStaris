using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using ScrappyStaris;
using ScrappyStaris.DbContexts;
using ScrappyStaris.Models;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SqliteContext>();
builder.Services.AddHttpClient();
var app = builder.Build();
var serviceProvider = app.Services;
var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

app.MapGet("/Character", (SqliteContext context) => {

    var _fetch = new Fetch(httpClientFactory);
    var _char = _fetch.GetInfoFromPeopleEndpoint().Result;

    List<Character> characterList = [];
    var id = 0;
    foreach (var character in _char) {
        id++;
        if (id == 17) {
            continue;
        }
        var infosChar = new Character() {
            Id = id,
            Name = character.GetProperty("name").ToString(),
            BirthYear = character.GetProperty("birth_year").ToString(),
            EyeColor = character.GetProperty("eye_color").ToString(),
            Gender = character.GetProperty("gender").ToString(),
            HairColor = character.GetProperty("hair_color").ToString(),
            Height = character.GetProperty("height").ToString(),
            Mass = character.GetProperty("mass").ToString(),
            SkinColor = character.GetProperty("skin_color").ToString()
        };
        characterList.Add(infosChar);
    }
    //context.Characters.AddRange(characterList);
    //context.SaveChanges();
    return characterList;
});

app.MapGet("/Films", (SqliteContext context) => {

    var _fetch = new Fetch(httpClientFactory);
    var _movie = _fetch.GetInfoFromFilmsEndpoint().Result;

    List<Movie> movieList = [];
    var id = 0;
    foreach (var movie in _movie) {
        id++;
        var infosMovie = new Movie() {
            Id = id,
            Title = movie.GetProperty("title").ToString(),
            Episode = int.Parse(movie.GetProperty("episode_id").ToString()),
            OpeningCrawl = movie.GetProperty("opening_crawl").ToString(),
            Director = movie.GetProperty("director").ToString(),
            Producer = movie.GetProperty("producer").ToString(),
            ReleaseDate = movie.GetProperty("release_date").ToString()
        };
        movieList.Add(infosMovie);
    }
    //context.Movies.AddRange(movieList);
    //context.SaveChanges();

    return movieList;
});
app.MapGet("/Planets", (SqliteContext context) => {

    var _fetch = new Fetch(httpClientFactory);
    var _planets = _fetch.GetInfoFromPlanetsEndpoint().Result;

    List<Planet> planetList = [];
    var id = 0;
    foreach (var planet in _planets) {
        id++;
        var infosPlanet = new Planet() {
            Id = id,
            Name = planet.GetProperty("name").ToString(),
            RotationSpeed = planet.GetProperty("rotation_period").ToString(),
            OrbitalPeriod = planet.GetProperty("orbital_period").ToString(),
            Diameter = planet.GetProperty("diameter").ToString(),
            Climate = planet.GetProperty("climate").ToString(),
            Gravity = planet.GetProperty("gravity").ToString(),
            Terrain = planet.GetProperty("terrain").ToString(),
            SurfaceWater = planet.GetProperty("surface_water").ToString(),
            Population = planet.GetProperty("population").ToString()
        };
        planetList.Add(infosPlanet);
    }
    //context.Planets.AddRange(planetList);
    //context.SaveChanges();

    return planetList;
});

app.MapGet("/Vehicles", (SqliteContext context) => {

    var _fetch = new Fetch(httpClientFactory);
    var _vehicle = _fetch.GetInfoFromVehiclesEndpoint().Result;

    List<Vehicle> vehicleList = [];
    var id = 0;
    foreach (var vehicle in _vehicle) {
        id++;
        if (!vehicle.TryGetProperty("name",out var x)){
            continue;
        }
        var infosVehicle = new Vehicle() {
            Id = id,
            Name = vehicle.GetProperty("name").ToString(),
            Model = vehicle.GetProperty("model").ToString(),
            Manufacturer = vehicle.GetProperty("manufacturer").ToString(),
            CostInCredits = vehicle.GetProperty("cost_in_credits").ToString(),
            Lenght = vehicle.GetProperty("length").ToString(),
            MaxAtmospheringSpeed = vehicle.GetProperty("max_atmosphering_speed").ToString(),
            Crew = vehicle.GetProperty("crew").ToString(),
            Passengers = vehicle.GetProperty("passengers").ToString(),
            CargoCapacity = vehicle.GetProperty("cargo_capacity").ToString(),
            Consumables = vehicle.GetProperty("consumables").ToString(),
            VehicleClass = vehicle.GetProperty("vehicle_class").ToString()
        };
        vehicleList.Add(infosVehicle);
    }
    //context.Vehicles.AddRange(vehicleList);
    //context.SaveChanges();
    return vehicleList;
});

app.MapGet("/Starships", (SqliteContext context) => {

    var _fetch = new Fetch(httpClientFactory);
    var _starship = _fetch.GetInfoFromStarshipsEndpoint().Result;

    List<Starship> starshipList = [];
    var id = 0;
    foreach (var starship in _starship) {
        id++;
        if (!starship.TryGetProperty("name", out var x)) {
            continue;
        }
        var infosStarship = new Starship() {
            Id = id,
            Name = starship.GetProperty("name").ToString(),
            Model = starship.GetProperty("model").ToString(),
            Manufacturer = starship.GetProperty("manufacturer").ToString(),
            CostInCredits = starship.GetProperty("cost_in_credits").ToString(),
            Lenght = starship.GetProperty("length").ToString(),
            MaxAtmospheringSpeed = starship.GetProperty("max_atmosphering_speed").ToString(),
            Crew = starship.GetProperty("crew").ToString(),
            Passengers = starship.GetProperty("passengers").ToString(),
            CargoCapacity = starship.GetProperty("cargo_capacity").ToString(),
            Consumables = starship.GetProperty("consumables").ToString(),
            HyperDriveRating = starship.GetProperty("hyperdrive_rating").ToString(),
            Megalights = starship.GetProperty("MGLT").ToString(),
            StarshipClass = starship.GetProperty("starship_class").ToString()
        };
        starshipList.Add(infosStarship);
    }
    context.Starships.AddRange(starshipList);
    context.SaveChanges();

    return starshipList;
});

app.Run();