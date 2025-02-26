using Todo.Core.Services;
using Todo.Core.Settings;

namespace Todo.Core.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddHttpClientServices(this IServiceCollection services, ToDoApiSettings apiSettings)
        {
            services.AddHttpClient<IToDoHttpService, ToDoHttpService>(client =>
            {
                client.BaseAddress = new Uri(apiSettings.BaseUrl);
            });
        }
    }
}
