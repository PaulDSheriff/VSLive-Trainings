using AdventureWorks.MAUI.ViewModelsCommanding;
using AdventureWorks.MAUI.Views;
using AdventureWorks.ViewModelLayer;
using Microsoft.Extensions.Logging;
#if WINDOWS
using Microsoft.Maui.LifecycleEvents;
#endif

namespace AdventureWorks.MAUI
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

      // Add services to be used in Dependency Injection
      builder.Services.AddTransient<UserViewModelCommanding>();
      builder.Services.AddTransient<UserDetailView>();

#if WINDOWS
  builder.ConfigureLifecycleEvents(events =>
  {
    events.AddWindows(wndLifeCycleBuilder =>
    {
      wndLifeCycleBuilder.OnWindowCreated(window =>
      {
        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        Microsoft.UI.WindowId win32WindowsId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
        Microsoft.UI.Windowing.AppWindow winuiAppWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(win32WindowsId);
        if (winuiAppWindow.Presenter is Microsoft.UI.Windowing.OverlappedPresenter p) {
          p.Maximize();
          //p.IsResizable = false;
          //p.IsMaximizable = false;
          //p.IsMinimizable = false;
        }
      });
    });
  });
#endif

#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}