using Microsoft.Extensions.Logging;
using AlVueloMobile.Services;
using AlVueloMobile.ViewModels;
using AlVueloMobile.Views;

namespace MainPage_AlVuelo_User
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // ================================
            // 🔹 DEPENDENCY INJECTION
            // ============================
