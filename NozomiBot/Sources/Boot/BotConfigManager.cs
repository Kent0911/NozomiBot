using System;
using System.IO;
using System.Text.Json;
using NozomiBot.Config;

namespace NozomiBot.Boot {
    internal class BotConfigManager {
        private static BotConfigData configData;

        public static string token { get; private set; } = string.Empty;
        public static string SQLConnectionString { get; private set; } = string.Empty;
        public static void setJsonConfig ( string _path ) {
            var jsonData = File.ReadAllText ( _path );
            configData = JsonSerializer.Deserialize<BotConfigData>( jsonData );
            token = configData.discordConfig.token;

            SQLConnectionString = $"server = { configData.databaseConfig.host }; " +
                $" port = { configData.databaseConfig.port }; " +
                $" user = { configData.databaseConfig.user }; " +
                $" password = { configData.databaseConfig.password }; " +
                $" database = { configData.databaseConfig.database }; " +
                $" sslMode = { configData.databaseConfig.sslMode }";
        }
    }
}
