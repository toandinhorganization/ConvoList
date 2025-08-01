using ConvoList.ViewModels;
using ConvoList.Services;
using ConvoList.Views;
using MauiApp1.Contants;
using Microsoft.Extensions.Logging;

namespace ConvoList.WinUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder
                .UseSharedMauiApp();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<TodoService>();
            builder.Services.AddTransient<TodoListPageViewModel>();
            builder.Services.AddTransient<TodoListPage>();
            return builder.Build();
        }
    }
}
