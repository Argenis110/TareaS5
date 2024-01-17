using Microsoft.Extensions.Logging;

namespace prueba_S5
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(Fonts =>
                {
                    Fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    Fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
            builder.Services.AddSingleton<PersonaRepository>(s => ActivatorUtilities.CreateInstance<PersonaRepository>(s, dbPath));

            return builder.Build();
        }
    }
}
