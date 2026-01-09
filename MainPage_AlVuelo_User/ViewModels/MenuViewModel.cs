using System.Collections.ObjectModel;
using System.Windows.Input;
using AlVueloMobile.Models;
using AlVueloMobile.Services;
using AlVueloMobile.Views;

namespace AlVueloMobile.ViewModels;

public class MenuViewModel : BindableObject, IQueryAttributable
{
    private readonly ApiService _api;

    public static readonly string[] Categorias = { "Desayuno", "Almuerzo", "Merienda", "Bebidas", "Snacks" };

    public ObservableCollection<string> ListaCategorias { get; } = new(Categorias);
    public ObservableCollection<PlatoDto> Platos { get; } = new();

    private string _restauranteId = "";
    private string _nombreRestaurante = "";
    public string NombreRestaurante { get => _nombreRestaurante; set { _nombreRestaurante = value; OnPropertyChanged(); } }

    private string _categoriaActual = "Desayuno";
    public string CategoriaActual { get => _categoriaActual; set { _categoriaActual = value; OnPropertyChanged(); } }

    public ICommand SelectCategoryCommand { get; }
    public ICommand OpenDishCommand { get; }

    public MenuViewModel(ApiService api)
    {
        _api = api;
        SelectCategoryCommand = new Command<string>(async c => await ChangeCategoryAsync(c));
        OpenDishCommand = new Command<PlatoDto>(async p => await OpenDishAsync(p));
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("restauranteId", out var idObj))
            _restauranteId = idObj?.ToString() ?? "";

        if (query.TryGetValue("nombre", out var nObj))
            NombreRestaurante = Uri.UnescapeDataString(nObj?.ToString() ?? "");
    }

    public async Task LoadAsync()
    {
        await LoadPlatosAsync();
    }

    private async Task ChangeCategoryAsync(string? cat)
    {
        if (string.IsNullOrWhiteSpace(cat)) return;
        CategoriaActual = cat;
        await LoadPlatosAsync();
    }

    private async Task LoadPlatosAsync()
    {
        Platos.Clear();
        var list = await _api.GetPlatosAsync(_restauranteId, CategoriaActual);
        foreach (var p in list) Platos.Add(p);
    }

    private async Task OpenDishAsync(PlatoDto? p)
    {
        if (p is null) return;
        await Shell.Current.GoToAsync($"{nameof(DishDetailPage)}?platoId={p.id}");
    }
}
