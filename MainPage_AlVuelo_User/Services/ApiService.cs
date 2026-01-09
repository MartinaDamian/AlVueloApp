using System.Net.Http.Json;
using AlVueloMobile.Models;

namespace AlVueloMobile.Services;

public class ApiService
{
    private readonly HttpClient _http;

    // Cambia el puerto por el de tu API cuando lo ejecutes (lo verás en la URL del navegador).
    private const string BaseUrl = "http://10.0.2.2:53217";

    public ApiService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<List<RestauranteDto>> GetRestaurantesAsync()
        => await _http.GetFromJsonAsync<List<RestauranteDto>>("/api/restaurantes") ?? new();

    public async Task<List<PlatoDto>> GetPlatosAsync(string restauranteId, string categoria)
        => await _http.GetFromJsonAsync<List<PlatoDto>>(
            $"/api/restaurantes/{restauranteId}/platos?categoria={Uri.EscapeDataString(categoria)}"
        ) ?? new();

    public async Task<PlatoDto?> GetPlatoAsync(int platoId)
        => await _http.GetFromJsonAsync<PlatoDto>($"/api/platos/{platoId}");
}
