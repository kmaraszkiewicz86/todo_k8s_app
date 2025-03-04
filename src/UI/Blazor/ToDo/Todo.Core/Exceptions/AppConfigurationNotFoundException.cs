namespace Todo.Core.Exceptions
{
    public class AppConfigurationNotFoundException(string configName) : Exception($"Config {configName} not found in appsettings file")
    {
    }
}
