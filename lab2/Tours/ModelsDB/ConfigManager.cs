using Microsoft.Extensions.Configuration;

namespace Tours
{
    public static class ConfigManager
    {
        public static string GetConnectionString(int AccessLevel)
        {
            IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();

            if (AccessLevel == 2)
            {
                return config["Connections:Manager"];
            }

            if (AccessLevel == 1)
            {
                return config["Connections:Tourist"];
            }

            return config["Connections:Guest"];
        }
    }
}
