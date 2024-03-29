﻿using ApplicationPropertiesSettings;
using KretaRazorPages.ExceptionHandler;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using ServiceKretaLogger;

namespace KretaRazorPages.Extensions
{
    public static class KretaRazorServiceExtensions
    {
        public static void ConfigureRazorPageServices(this IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");
            services.AddMvc()
                .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();         
        }

        public static void ConfigureLocalization(this IServiceCollection services)
        {
            CultureProperties properties = new CultureProperties();
            var supportedCultures = new[] { properties.GetDefaultCulture(), "en-US" };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                  new QueryStringRequestCultureProvider(),
                  new CookieRequestCultureProvider()
                };
            });         
        }

        // Loggolás
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // Hibakezelés
        public static void ConfigureCustomExceptionMiddleware(this IServiceCollection services )
        {
            services.AddScoped<IMiddleware,ExceptionMiddleware>();
        }

        public static void ConfigureComponentsService(this IServiceCollection services)
        {            
        }
    }
}
