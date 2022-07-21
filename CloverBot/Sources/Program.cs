using System.IO;
using System.Threading.Tasks;
using CloverBot.Boot;

namespace CloverBot.MainScript {
    internal class Program {
        private CloverBot cloverBot = new CloverBot();
        private static readonly string configPath = Path.Combine("data", "botConfig.json");

        static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync() {
            BotConfigManager.setJsonConfig(configPath);
            await Task.Run(cloverBot.BotAsync);
        }
    }
}

