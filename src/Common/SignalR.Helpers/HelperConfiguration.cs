namespace SignalR.Helpers
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class HelperConfiguration
    {
        public static AppConfiguration GetAppConfiguration(string configurationFile = "App.json")
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                                    .AddJsonFile(configurationFile, optional: true)
                                                    .Build();


            var result = configuration.Get<AppConfiguration>();

            return result;
        }
    }
}
