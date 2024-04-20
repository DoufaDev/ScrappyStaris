using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace ScrappyStaris;
public class Fetch {

    private string _url = "https://swapi.dev/api/";
    private readonly IHttpClientFactory _httpClientFactory;

    public Fetch(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<JsonElement>> GetInfoFromPeopleEndpoint() {
        var endpoint = "people";
        var client = _httpClientFactory.CreateClient();

        List<JsonElement> infos = new List<JsonElement>();

        for (int i = 1; i <= 83; i++) {
            var response = await client.GetAsync($"{_url}/{endpoint}/{i}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);
            var root = bodyMessage.RootElement;
            infos.Add(root);
        }
        return infos;
    }
    public async Task<List<JsonElement>> GetInfoFromFilmsEndpoint() {
        var endpoint = "films";
        var client = _httpClientFactory.CreateClient();

        List<JsonElement> infos = new List<JsonElement>();

        for (int i = 1; i <= 6; i++) {
            var response = await client.GetAsync($"{_url}/{endpoint}/{i}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);
            var root = bodyMessage.RootElement;
            infos.Add(root);
        }
        return infos;
    }
    public async Task<List<JsonElement>> GetInfoFromPlanetsEndpoint() {
        var endpoint = "planets";
        var client = _httpClientFactory.CreateClient();

        List<JsonElement> infos = new List<JsonElement>();

        for (int i = 1; i <= 60; i++) {
            var response = await client.GetAsync($"{_url}/{endpoint}/{i}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);
            var root = bodyMessage.RootElement;
            infos.Add(root);
        }
        return infos;
    }

    public async Task<List<JsonElement>> GetInfoFromVehiclesEndpoint() {
        var endpoint = "vehicles";
        var client = _httpClientFactory.CreateClient();

        List<JsonElement> infos = new List<JsonElement>();

        for (int i = 1; i <= 76; i++) {
            var response = await client.GetAsync($"{_url}/{endpoint}/{i}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);
            var root = bodyMessage.RootElement;
            infos.Add(root);
        }
        return infos;
    }

    public async Task<List<JsonElement>> GetInfoFromStarshipsEndpoint() {
        var endpoint = "starships";
        var client = _httpClientFactory.CreateClient();

        List<JsonElement> infos = new List<JsonElement>();

        for (int i = 1; i <= 75; i++) {
            var response = await client.GetAsync($"{_url}/{endpoint}/{i}");
            var stream = await response.Content.ReadAsStreamAsync();
            var bodyMessage = await JsonDocument.ParseAsync(stream);
            var root = bodyMessage.RootElement;
            infos.Add(root);
        }
        return infos;
    }
}
