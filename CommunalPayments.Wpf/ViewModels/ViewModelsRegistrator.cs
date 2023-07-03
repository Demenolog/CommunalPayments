using Microsoft.Extensions.DependencyInjection;

namespace CommunalPayments.Wpf.ViewModels
{
    internal static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<DataViewWindowViewModel>();
    }
}