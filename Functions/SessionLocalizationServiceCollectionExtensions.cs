using Functions.Localization;
using Microsoft.Extensions.Localization;

namespace Assessment.Functions
{
    public static class SessionLocalizationServiceCollectionExtensions
    {
        public static void AddSessionLocalization(this IServiceCollection services)
        {
            services.AddTransient<IStringLocalizerFactory, SessionStringLocalizerFactory>();
            services.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
        }
    }
}
