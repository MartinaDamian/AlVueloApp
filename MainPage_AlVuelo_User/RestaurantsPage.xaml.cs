using AlVueloMobile.ViewModels;

namespace AlVueloMobile.Views;

public partial class RestaurantsPage : ContentPage
{
    private readonly RestaurantsViewModel _vm;

    public RestaurantsPage(RestaurantsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAsync();
    }
}
