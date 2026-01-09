using AlVueloMobile.Models;
using AlVueloMobile.Services;

namespace AlVueloMobile.ViewModels;

public class DishDetailViewModel : BindableObject, IQueryAttributable
{
    private readonly ApiService _api;

    private PlatoDto? _plato;
    public PlatoDto? Plato { get => _plato; set { _plato = value; OnPropertyChanged(); } }

    public DishDetailViewModel(ApiService api) => _api = api;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("platoId", out var idObj)) return;
        var id = Convert.ToInt32(idObj);
        Plato = await _api.GetPlatoAsync(id);
    }
}
