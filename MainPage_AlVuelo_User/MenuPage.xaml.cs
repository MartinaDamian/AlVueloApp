using AlVueloMobile.ViewModels;

namespace AlVueloMobile.Views;

public partial class MenuPage : ContentPage
{
    private readonly MenuViewModel _vm;

    public MenuPage(MenuViewModel vm)
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
