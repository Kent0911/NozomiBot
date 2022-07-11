using System.Text.Json.Serialization;

namespace CloverBot.Config {
    internal class BotConfigData {
        [JsonPropertyName("discord")]
        public DiscordConfig discordConfig { get; set; }

        [JsonPropertyName("database")]
        public DatabaseConfig databaseConfig { get; set; }

        public class DiscordConfig {
            [JsonPropertyName("token")]
            public string token { get; set; } 
        }
        
        public class DatabaseConfig {
            [JsonPropertyName("host")]
            public string host { get; set; }
            
            [JsonPropertyName("port")]
            public string port { get; set; }

            [JsonPropertyName("user")]
            public string user { get; set; }

            [JsonPropertyName("password")]
            public string password { get; set; }

            [JsonPropertyName("database")]
            public string database { get; set; }

            [JsonPropertyName("sslmode")]
            public string sslMode { get; set; }
        }
    }
}