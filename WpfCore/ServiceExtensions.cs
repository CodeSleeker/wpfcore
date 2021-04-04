using Microsoft.Extensions.DependencyInjection;

namespace WpfCore
{
    public static class ServiceExtensions
    {
        public static ServiceProvider serviceProvider = new ServiceCollection().BuildServiceProvider();
        public static T Service<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}
