using Microsoft.Extensions.Configuration;
using Todo.Core.Settings;

namespace Todo.Core.Extensions
{
    public static class ConfigurationExtension
    {
        public static ToDoApiSettings? GenerateApiSettings(this IConfiguration configuration)
        {
            return configuration.GetSection("ToDoApiSettings").Get<ToDoApiSettings>();
        }
    }
}
