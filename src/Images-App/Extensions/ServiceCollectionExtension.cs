using Images_App.Application.Interfaces;
using Images_App.Application.Service;
using Images_App.Application.UseCases;
using Images_App.Application.UseCases.Interfaces;
using Images_App.DataPersistence;
using Images_App.DataPersistence.Repositories;

namespace Images_App.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ISaveImageUseCase, SaveImageUseCase>();
            services.AddTransient<ImageService>();

            return services;
        }

        public static IServiceCollection AddDataPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<MyDBContext>();
            services.AddTransient<IImageRepository, ImageRepository>();
            return services;
        }
    }
}
