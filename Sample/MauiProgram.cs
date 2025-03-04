using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Maui.Controls.Compatibility;

namespace OnBoardHelpDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Satisfy-Regular.ttf", "Satisfy-Regular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //builder.UseMauiCompatibility();
            return builder.Build();
        }
    }
}
