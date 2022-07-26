using System.IO;
using System.Threading.Tasks;
using NozomiBot.Boot;

namespace NozomiBot.MainScript {
    internal class Program {
        private NozomiBot nozomiBot = new NozomiBot();
        private static readonly string configPath = Path.Combine( "data", "botConfig.json" );

        static void Main() => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync() {
            BotConfigManager.setJsonConfig( configPath );
            await Task.Run( nozomiBot.BotAsync );
        }
    }
}

