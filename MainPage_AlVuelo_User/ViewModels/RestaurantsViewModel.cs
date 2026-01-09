using AlVueloMobile.Models;
using AlVueloMobile.Services;
using AlVueloMobile.Views;
using MainPage_AlVuelo_User.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlVueloMobile.ViewModels;

public class RestaurantsViewModel : BindableObject
{
    private readonly ApiService _api;

    public ObservableCollection<RestauranteDto> Restaurantes { get; } = new();

    public ICommand LoadCommand { get; }
    public ICommand OpenRestaurantCommand { get; }

    public RestaurantsViewModel(ApiService api)
    {
        _api = api;
        LoadCommand = new Command(async () => await LoadAsync());
        OpenRestaurantCommand = new Command<RestauranteDto>(async r => await OpenRestaurantAsync(r));
    }

    public async Task LoadAsync()
    {
        Restaurantes.Clear();
        var list = await _api.GetRestaurantesAsync();
        foreach (var r in list) Restaurantes.Add(r);
    }

    private async Task OpenRestaurantAsync(RestauranteDto? r)
    {
        if (r is null) return;
        await Shell.Current.GoToAsync($"{nameof(MenuPage)}?restauranteId={r.id}&nombre={Uri.EscapeDataString(r.nombre)}");
    }
}
