using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ConvoList.ContentViews;
using ConvoList.Services;
namespace ConvoList
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<TodoService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder;
        }
    }
}
