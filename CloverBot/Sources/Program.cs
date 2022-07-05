using System;
using System.IO;
using System.Threading.Tasks;
using CloverBot.Boot;

namespace CloverBot.Script {
    public class Program {
        private CloverBot cloverBot;

        private static readonly string configPath = Path.Combine("data", "botConfig.json");

        // Botの起動処理
        static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
        public Task MainAsync() { 
            BotConfigManager.setJsonConfig(configPath);

            cloverBot = new CloverBot();
            return Task.CompletedTask;
        }
    }
}