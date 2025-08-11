using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace RTC_Stock_Management
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemiBold");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
#if ANDROID
        BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("DisableOverscroll", (handler, view) =>
        {
            try
            {
                if (handler.PlatformView is Android.Webkit.WebView webView)
                {
                    webView.OverScrollMode = Android.Views.OverScrollMode.Never;
                }
            }
            catch {}
        });
#endif
            return builder.Build();
        }
    }
}
